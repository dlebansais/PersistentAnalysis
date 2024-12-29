#pragma warning disable IDE0060 // Remove unused parameter

namespace PersistentAnalysis;

using System;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Contracts;
using DebugLogging;
using Microsoft.Extensions.Logging;
using NodeClone;
using ProcessCommunication;

/// <summary>
/// Provides tools for analyzers that need persistence.
/// </summary>
public static partial class Persist
{
    private const string HostResourceName = "PersistentAnalysisHost.exe";

    /// <summary>
    /// Gets the default client GUID.
    /// </summary>
    public static Guid ClientGuid { get; } = new("F54476ED-C30B-4D3B-949F-A01A75B57F7D");

    /// <summary>
    /// Initializes persistence.
    /// This method is intended for the client side.
    /// A program might need several attempts at initialization before it's successful.
    /// </summary>
    /// <param name="duration">The persistence duration. Use <see cref="TimeSpan.Zero"/> for no limit.</param>
    /// <param name="analyzerFileName">The analyzer file name.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool Init(TimeSpan duration, string analyzerFileName)
    {
        InitProlog(duration, out string Arguments);

        IChannel? NewChannel = Remote.LaunchAndOpenChannel(HostResourceName, UpdateChannelGuid, Arguments);
        SetUpdateChannel(NewChannel);

        bool IsOpen = UpdateChannel is not null && UpdateChannel.IsOpen;

        if (IsOpen)
            SendInit(analyzerFileName);

        Trace($"Open: {IsOpen}");

        return IsOpen;
    }

    /// <summary>
    /// Initializes persistence.
    /// This method is intended for the client side.
    /// </summary>
    /// <param name="duration">The persistence duration. Use <see cref="TimeSpan.Zero"/> for no limit.</param>
    /// <param name="analyzerFileName">The analyzer file name.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static async Task<bool> InitAsync(TimeSpan duration, string analyzerFileName)
    {
        InitProlog(duration, out string Arguments);

        IChannel? NewChannel = await Remote.LaunchAndOpenChannelAsync(HostResourceName, UpdateChannelGuid, Arguments).ConfigureAwait(false);
        SetUpdateChannel(NewChannel);

        bool IsOpen = UpdateChannel is not null;

        Trace($"Open: {IsOpen}");

        if (IsOpen)
            SendInit(analyzerFileName);

        return IsOpen;
    }

    private static void InitProlog(TimeSpan duration, out string arguments)
    {
        if (UpdateChannelGuid == Guid.Empty)
        {
            UpdateChannelGuid = Guid.NewGuid();
            DiagnosticChannelGuid = Guid.NewGuid();
        }

        int Seconds = (int)duration.TotalSeconds;
        arguments = $"{UpdateChannelGuid} {DiagnosticChannelGuid} {Seconds}";

        // Propagate the max duration to the debugger.
        if (duration > TimeSpan.Zero)
            Logger.DisplayAppArguments = $"{Seconds + 60}";

        if (DiagnosticChannel is null)
        {
            Channel NewChannel = new(DiagnosticChannelGuid, ChannelMode.Receive);
            NewChannel.Open();
            Contract.Assert(NewChannel.IsOpen);

            SetDiagnosticChannel(NewChannel);
        }
    }

    private static void SendInit(string analyzerFileName)
    {
        string Version = $"{Assembly.GetExecutingAssembly().GetName().Version}";
        _ = Send(new Command(new InitCommand(ClientGuid.ToString(), Version, "SampleAnalyzer.dll")));
    }

    /// <summary>
    /// Exits persistence.
    /// This method is intended for the client side.
    /// </summary>
    /// <param name="delay">An optional delay before clean up.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool Exit(TimeSpan delay)
    {
        if (UpdateChannel is null || !UpdateChannel.IsOpen)
            throw new InvalidOperationException();

        bool IsExitSent = Send(new Command(new ExitCommand(delay)));

        UpdateChannel.Close();
        SetUpdateChannel(null);

        IChannel DisposedChannel = Contract.AssertNotNull(DiagnosticChannel);
        DisposedChannel.Close();

        SetDiagnosticChannel(null);

        return IsExitSent;
    }

    /// <summary>
    /// Updates the current persistent state with default values for the machine, solution and project.
    /// This method is intended for the client side.
    /// </summary>
    /// <param name="root">The new root.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool Update(CompilationUnitSyntax root)
        => Update(null, null, null, root);

    /// <summary>
    /// Updates the current persistent state.
    /// This method is intended for the client side.
    /// </summary>
    /// <param name="deviceId">The unique ID of the device on which the caller is running, or <see langword="null"/> for the local machine.</param>
    /// <param name="solutionPath">The full path to the solution file, or <see langword="null"/> for a default solution.</param>
    /// <param name="projectPath">The full path to the project file, or <see langword="null"/> for a default project.</param>
    /// <param name="root">The new root.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool Update(string? deviceId, string? solutionPath, string? projectPath, CompilationUnitSyntax root)
    {
        if (UpdateChannel is null || !UpdateChannel.IsOpen)
            throw new InvalidOperationException();

        ReportReceivedDiagnostics();

        if (deviceId is null)
            WindowsDeviceId ??= GetWindowsDeviceId();

        return Send(new Command(new UpdateCommand(deviceId ?? WindowsDeviceId, solutionPath, projectPath, root)));
    }

    private static void ReportReceivedDiagnostics()
    {
        IChannel Channel = Contract.AssertNotNull(DiagnosticChannel);

        string? LastJsonText = null;
        while (Channel.TryRead(out byte[] Data))
        {
            int Offset = 0;
            while (Converter.TryDecodeString(Data, ref Offset, out string JsonText))
                LastJsonText = JsonText;
        }

        if (LastJsonText is not null)
        {
            AnalyzerDiagnosticCollection Diagnostics = Contract.AssertNotNull(JsonSerializer.Deserialize<AnalyzerDiagnosticCollection>(LastJsonText));
            RaiseDiagnosticChanged(new DiagnosticChangedEventArgs(Diagnostics));
        }
    }

    /// <summary>
    /// Parses a string containing requests and updates from the client.
    /// This method is intended for the host side.
    /// </summary>
    /// <param name="text">The string to parse.</param>
    public static void Parse(string text)
    {
        try
        {
            if (JsonSerializer.Deserialize<Command>(text, DeserializingOptions) is Command Command)
                Parse(Command);
        }
        catch (JsonException e)
        {
#pragma warning disable CA1848
            Logger.LogError(e, "Exception while deserializing a command.");
#pragma warning restore CA1848
        }
    }

    private static void SetUpdateChannel(IChannel? updateChannel)
    {
        UpdateChannel?.Dispose();

        UpdateChannel = updateChannel;
    }

    private static void SetDiagnosticChannel(IChannel? diagnosticChannel)
    {
        DiagnosticChannel?.Dispose();

        DiagnosticChannel = diagnosticChannel;
    }

    private static Guid UpdateChannelGuid = Guid.Empty;
    private static Guid DiagnosticChannelGuid = Guid.Empty;
    private static IChannel? UpdateChannel;
    private static IChannel? DiagnosticChannel;
    private static readonly DebugLogger Logger = new();
    private static string? WindowsDeviceId;
}
