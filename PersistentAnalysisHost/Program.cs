namespace PersistentAnalysisHost;

using System;
using System.Diagnostics;
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
        Guid UpdateChannelGuid;
        Guid DiagnosticChannelGuid;

        if (args.Length <= 1 || !Guid.TryParse(args[0], out UpdateChannelGuid) || !Guid.TryParse(args[1], out DiagnosticChannelGuid))
            return;

        if (args.Length > 2 && int.TryParse(args[2], out int MaxDuration) && MaxDuration > 0)
        {
            ExitTimeout = TimeSpan.FromSeconds(MaxDuration);

            // Propagate the max duration to the debugger.
            Logger.DisplayAppArguments = $"{MaxDuration + 60}";

            Trace($"Persistence Host starting, exit timeout: {ExitTimeout}");
        }
        else
            Trace("Persistence Host starting, no timeout");

        Trace($"Update guid: {UpdateChannelGuid}");
        Trace($"Diagnostic guid: {DiagnosticChannelGuid}");

        UpdateChannel = new Channel(UpdateChannelGuid, ChannelMode.Receive);
        UpdateChannel.Open();

        if (!UpdateChannel.IsOpen)
        {
            Trace("Another process is listening to the same update channel, aborting");
            Process.GetCurrentProcess().Kill();
        }

        DiagnosticChannel = new Channel(DiagnosticChannelGuid, ChannelMode.Send);
        DiagnosticChannel.Open();

        if (!DiagnosticChannel.IsOpen)
        {
            Trace("Unable to open diagnostic channel, aborting");

            UpdateChannel.Close();
            Process.GetCurrentProcess().Kill();
        }

        Trace("Listening");

        Persist.ExitRequested += OnExitRequested;
        Persist.DiagnosticChanged += OnDiagnosticChanged;

        Stopwatch Stopwatch = Stopwatch.StartNew();
        while (Stopwatch.Elapsed < ExitTimeout)
        {
            Thread.Sleep(500);
            Trace("Reading");

            if (UpdateChannel.TryRead(out byte[] Data))
            {
                int Offset = 0;
                while (Converter.TryDecodeString(Data, ref Offset, out string Text))
                {
                    Trace("Data received");
                    Persist.Parse(Text);
                }

                Stopwatch.Restart();
            }
        }

        Trace("No longer listening");

        Persist.ExitRequested -= OnExitRequested;
        Persist.DiagnosticChanged -= OnDiagnosticChanged;

        UpdateChannel.Close();
        DiagnosticChannel.Close();

        Trace("End");
    }

    private static void OnExitRequested(object? sender, EventArgs args)
    {
        ExitTimeout = TimeSpan.FromSeconds(1);
    }

    private static void OnDiagnosticChanged(object? sender, DiagnosticChangedEventArgs args)
    {
        var Diagnostics = args.Diagnostics;
        string JsonText = JsonSerializer.Serialize(Diagnostics);
        byte[] Data = Converter.EncodeString(JsonText);
        IChannel Channel = Contract.AssertNotNull(DiagnosticChannel);

        if (Channel.GetFreeLength() >= Data.Length)
            Channel.Write(Data);
    }

    private static void Trace(string message)
    {
        Logger.Log(message);
    }

    private static IChannel? UpdateChannel;
    private static IChannel? DiagnosticChannel;
    private static readonly DebugLogger Logger = new();
    //private static TimeSpan ExitTimeout = TimeSpan.FromDays(100000);
    private static TimeSpan ExitTimeout = TimeSpan.FromSeconds(30);
}
