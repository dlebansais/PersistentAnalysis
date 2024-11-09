namespace PersistentAnalysis;

using System;
using System.Globalization;

/// <summary>
/// Provides tools for analyzers that need persistence.
/// </summary>
public static partial class Persist
{
    /// <summary>
    /// Parses a command.
    /// </summary>
    /// <param name="command">The command to parse.</param>
    internal static void Parse(Command command)
    {
        if (command.InitCommand is InitCommand InitCommand)
            ParseInit(InitCommand);
    }

    private static void ParseInit(InitCommand initCommand)
    {
        string ClientGuidString;
        const string Unknown = "Unknown";

        if (Guid.TryParse(initCommand.ClientGuid, out Guid ParsedGuid))
            ClientGuidString = ParsedGuid == ClientGuid ? $"{nameof(Persist)} ({ParsedGuid})" : $"{ParsedGuid}";
        else
            ClientGuidString = Unknown;

        string VersionString = initCommand.Version ?? Unknown;

        Trace($"INIT {nameof(InitCommand.ClientGuid)}: {ClientGuidString}, {nameof(InitCommand.Version)}: {VersionString}");
    }

    private static void ParseExit(ExitCommand exitCommand)
    {
        string DelayString = exitCommand.Delay.ToString("c", CultureInfo.InvariantCulture);

        Trace($"EXIT {nameof(ExitCommand.Delay)}: {DelayString}");

        RaiseExitRequested(exitCommand.Delay);
    }

    /// <summary>
    /// Event signaled when exit is requested by a client.
    /// </summary>
    public static event EventHandler<ExitRequestedEventArgs>? ExitRequested;

    private static void RaiseExitRequested(TimeSpan delay)
    {
        ExitRequested?.Invoke(null, new ExitRequestedEventArgs(delay));
    }

    private static void ParseUpdate(UpdateCommand updateCommand)
    {
        Trace($"UPDATE");
    }
}
