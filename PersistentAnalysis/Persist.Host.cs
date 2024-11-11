namespace PersistentAnalysis;

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using NodeClone;
using ProcessCommunication;

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
    /// Gets the last analyzer file name.
    /// </summary>
    public static string LastAnalyzerFileName { get; private set; } = string.Empty;

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
        string AnalyzerFileNameString;
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

        if (initCommand.AnalyzerFileName is string ParsedAnalyzerFileNameString)
        {
            LastAnalyzerFileName = ParsedAnalyzerFileNameString;
            AnalyzerFileNameString = ParsedAnalyzerFileNameString;
        }
        else
        {
            LastAnalyzerFileName = string.Empty;
            AnalyzerFileNameString = Unknown;
        }

        Trace($"INIT {nameof(InitCommand.ClientGuid)}: {ClientGuidString}, {nameof(InitCommand.Version)}: {VersionString}, {nameof(InitCommand.AnalyzerFileName)}: {AnalyzerFileNameString}");

        if (LastAnalyzerFileName != string.Empty)
            LoadAnalyzer(LastAnalyzerFileName);
    }

    private static void LoadAnalyzer(string analyzerFileName)
    {
        string LoadStatus = string.Empty;

        try
        {
            string AnalyzerPath = Remote.GetSiblingFullPath(analyzerFileName);
            Assembly AnalyzerAssembly = Assembly.LoadFile(AnalyzerPath);
            Type AnalyzerApiType = AnalyzerAssembly.GetTypes()
                                                   .FirstOrDefault(type => typeof(IAnalyzerApi).IsAssignableFrom(type))
                                                   ?? throw new DllNotFoundException($"{AnalyzerPath} not found.");
            AnalyzerInstance = (Activator.CreateInstance(AnalyzerApiType) as IAnalyzerApi) ?? throw new InvalidOperationException($"Unable to create instance of {AnalyzerApiType.FullName}.");
            AnalyzerInstance.DiagnosticChangedEvent += OnDiagnosticChanged;

            LoadStatus = $"Loaded Analyzer: {AnalyzerPath}, Selected API: {AnalyzerApiType.Name}";
        }
        catch (Exception e)
        {
            LoadStatus = e.Message;
        }

        Trace(LoadStatus);
    }

    private static void ParseExit(ExitCommand exitCommand)
    {
        string DelayString = exitCommand.Delay.ToString("c", CultureInfo.InvariantCulture);

        Trace($"EXIT {nameof(ExitCommand.Delay)}: {DelayString}");

        if (AnalyzerInstance is not null)
            AnalyzerInstance.DiagnosticChangedEvent -= OnDiagnosticChanged;

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
        Trace("UPDATE");

        if (AnalyzerInstance is not null && updateCommand.Root is CompilationUnitSyntax Root)
            AnalyzerInstance.Update(Root);
    }

    private static void OnDiagnosticChanged(object? sender, DiagnosticChangedEventArgs args)
    {
        Trace("DiagnosticChanged");
    }

    private static IAnalyzerApi? AnalyzerInstance;
}
