namespace PersistentAnalysisHost;

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using Contracts;
using DebugLogging;
using PersistentAnalysis;
using ProcessCommunication;

internal class Program
{
    public static void Main(string[] args)
    {
        Trace("Starting");

        using Stream? Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(Program).Assembly.GetName().Name}.ChannelGuid.txt");
        Stream ResourceStream = Contract.AssertNotNull(Stream);
        using StreamReader Reader = new(ResourceStream);
        string GuidString = Reader.ReadToEnd();
        Guid ChannelGuid = new(GuidString);

        Channel = new Channel(ChannelGuid, Mode.Receive);
        Channel.Open();

        if (!Channel.IsOpen)
        {
            Trace("Another process is listening to the same channel, aborting");
            Process.GetCurrentProcess().Kill();
        }

        Trace("Listening");

        Persist.ExitRequested += OnExitRequested;

        Stopwatch Stopwatch = Stopwatch.StartNew();
        while (Stopwatch.Elapsed < ExitTimeout)
        {
            Thread.Sleep(50);

            if (Channel.Read() is byte[] Data)
            {
                int Offset = 0;
                while (Converter.TryDecodeString(Data, ref Offset, out string Text))
                {
                    Trace("Data received");
                    Persist.Parse(Text);
                }
            }
        }

        Trace("End");
    }

    private static void OnExitRequested(object? sender, EventArgs args)
    {
        ExitTimeout = TimeSpan.FromSeconds(1);
    }

    private static void Trace(string message)
    {
        Logger.Log(message);
    }

    private static Channel? Channel;
    private static readonly DebugLogger Logger = new();
    private static TimeSpan ExitTimeout = Timeout.InfiniteTimeSpan;
}
