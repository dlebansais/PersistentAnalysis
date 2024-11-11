namespace PersistentAnalysis;

using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading;
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
    private const string ChannelGuidResourceName = "ChannelGuid.txt";
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
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool Init(TimeSpan duration)
    {
        Guid ChannelGuid = new(GetResourceString(ChannelGuidResourceName));
        int Seconds = (int)duration.TotalSeconds;
        string Arguments = Seconds.ToString(CultureInfo.InvariantCulture);

        // Propagate the max duration to the debugger.
        if (duration > TimeSpan.Zero)
            Logger.DisplayAppArguments = $"{Seconds + 60}";

        IChannel? NewChannel = Remote.LaunchAndOpenChannel(HostResourceName, ChannelGuid, Arguments);
        SetChannel(NewChannel);

        bool IsOpen = Channel is not null && Channel.IsOpen;

        if (IsOpen)
            SendInit();

        Trace($"Open: {IsOpen}");

        return IsOpen;
    }

    /// <summary>
    /// Initializes persistence.
    /// This method is intended for the client side.
    /// </summary>
    /// <param name="duration">The persistence duration. Use <see cref="TimeSpan.Zero"/> for no limit.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static async Task<bool> InitAsync(TimeSpan duration)
    {
        Guid ChannelGuid = new(GetResourceString(ChannelGuidResourceName));
        int Seconds = (int)duration.TotalSeconds;
        string Arguments = Seconds.ToString(CultureInfo.InvariantCulture);

        // Propagate the max duration to the debugger.
        if (duration > TimeSpan.Zero)
            Logger.DisplayAppArguments = $"{Seconds + 60}";

        IChannel? NewChannel = await Remote.LaunchAndOpenChannelAsync(HostResourceName, ChannelGuid, Arguments).ConfigureAwait(false);
        SetChannel(NewChannel);

        bool IsOpen = Channel is not null;

        Trace($"Open: {IsOpen}");

        if (IsOpen)
            SendInit();

        return IsOpen;
    }

    private static string GetResourceString(string resourceName)
    {
        using Stream? Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(Persist).Assembly.GetName().Name}.Resources.{resourceName}");
        Stream ResourceStream = Contract.AssertNotNull(Stream);
        using StreamReader Reader = new(ResourceStream);

        return Reader.ReadToEnd();
    }

    private static void SendInit()
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
        if (Channel is null || !Channel.IsOpen)
            throw new InvalidOperationException();

        bool IsExitSent = Send(new Command(new ExitCommand(delay)));

        Channel.Close();
        SetChannel(null);

        return IsExitSent;
    }

    /// <summary>
    /// Updates the current persistent state with default values for the machine, solution and project.
    /// This method is intended for the client side.
    /// </summary>
    /// <param name="root">The new root.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool Update(CompilationUnitSyntax root)
    {
        return Update(null, null, null, root);
    }

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
        if (Channel is null || !Channel.IsOpen)
            throw new InvalidOperationException();

        if (deviceId is null)
            WindowsDeviceId = WindowsDeviceId ?? GetWindowsDeviceId();

        return Send(new Command(new UpdateCommand(deviceId ?? WindowsDeviceId, solutionPath, projectPath, root)));
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

    private static void SetChannel(IChannel? channel)
    {
        Channel?.Dispose();

        Channel = channel;
    }

    private static IChannel? Channel;
    private static readonly DebugLogger Logger = new();
    private static string? WindowsDeviceId;
}
