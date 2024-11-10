namespace PersistentAnalysis;

using System;
using System.Globalization;

/// <summary>
/// Provides tools for analyzers that need persistence.
/// </summary>
public static partial class Persist
{
    /// <summary>
    /// Gets the last client unique ID.
    /// </summary>
    public static Guid LastClientGuid { get; private set; } = Guid.Empty;

    /// <summary>
    /// Gets the last client version.
    /// </summary>
    public static string LastClientVersion { get; private set; } = string.Empty;

    /// <summary>
    /// Parses a command.
    /// </summary>
    /// <param name="command">The command to parse.</param>
    internal static void Parse(Command command)
    {
        if (command.InitCommand is InitCommand InitCommand)
            ParseInit(InitCommand);
        else if (command.ExitCommand is ExitCommand ExitCommand)
            ParseExit(ExitCommand);
        else if (command.UpdateCommand is UpdateCommand UpdateCommand)
            ParseUpdate(UpdateCommand);
        else
            throw new ArgumentException("Invalid command", nameof(command));
    }

    private static void ParseInit(InitCommand initCommand)
    {
        string ClientGuidString;
        string VersionString;
        const string Unknown = "Unknown";

        if (Guid.TryParse(initCommand.ClientGuid, out Guid ParsedGuid))
        {
            LastClientGuid = ParsedGuid;
            ClientGuidString = ParsedGuid == ClientGuid ? $"{nameof(Persist)} ({ParsedGuid})" : $"{ParsedGuid}";
        }
        else
        {
            LastClientGuid = Guid.Empty;
            ClientGuidString = Unknown;
        }

        if (initCommand.Version is string ParsedVersion)
        {
            LastClientVersion = ParsedVersion;
            VersionString = ParsedVersion;
        }
        else
        {
            LastClientVersion = string.Empty;
            VersionString = Unknown;
        }

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
