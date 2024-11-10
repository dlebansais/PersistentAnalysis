﻿namespace PersistentAnalysisHost;

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
        if (args.Length > 0 && int.TryParse(args[0], out int MaxDuration) && MaxDuration > 0)
        {
            ExitTimeout = TimeSpan.FromSeconds(MaxDuration);

            // Propagate the max duration to the debugger.
            Logger.DisplayAppArguments = $"{MaxDuration + 300}";

            Trace($"Starting, exit timeout is: {ExitTimeout}");
        }
        else
            Trace("Starting, no timeout");

        using Stream? Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(Program).Assembly.GetName().Name}.ChannelGuid.txt");
        Stream ResourceStream = Contract.AssertNotNull(Stream);
        using StreamReader Reader = new(ResourceStream);
        string GuidString = Reader.ReadToEnd();
        Guid ChannelGuid = new(GuidString);

        Channel = new Channel(ChannelGuid, ChannelMode.Receive);
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
            Thread.Sleep(500);
            Trace("Reading");

            if (Channel.TryRead(out byte[] Data))
            {
                int Offset = 0;
                while (Converter.TryDecodeString(Data, ref Offset, out string Text))
                {
                    Trace("Data received");
                    Persist.Parse(Text);
                }
            }
        }

        Trace("No longer listening");

        Channel.Close();

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
    //private static TimeSpan ExitTimeout = TimeSpan.FromDays(100000);
    private static TimeSpan ExitTimeout = TimeSpan.FromSeconds(30);
}
