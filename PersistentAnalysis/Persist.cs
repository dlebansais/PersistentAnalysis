namespace PersistentAnalysis;

using System;
using System.IO;
using System.Reflection;
using Contracts;
using DebugLogging;
using NodeClone;
using ProcessCommunication;

/// <summary>
/// Provides tools for analyzers that need persistence.
/// </summary>
public static partial class Persist
{
    /// <summary>
    /// Gets the default client GUID.
    /// </summary>
    public static Guid ClientGuid { get; } = new("F54476ED-C30B-4D3B-949F-A01A75B57F7D");

    /// <summary>
    /// Initializes persistence.
    /// A program might need several attempts at initialization before it's successful.
    /// </summary>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool Init()
    {
        using Stream? Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(Persist).Assembly.GetName().Name}.Resources.ChannelGuid.txt");
        Stream ResourceStream = Contract.AssertNotNull(Stream);
        using StreamReader Reader = new(ResourceStream);
        string GuidString = Reader.ReadToEnd();
        Guid ChannelGuid = new(GuidString);

        Channel = Remote.LaunchAndOpenChannel("PersistentAnalysisHost.exe", ChannelGuid);
        bool IsOpen = Channel is not null && Channel.IsOpen;

        Trace($"Open: {IsOpen}");

        if (IsOpen)
        {
            string? Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
            _ = Send(Command.Create(new InitCommand()
            {
                ClientGuid = ClientGuid.ToString(),
                Version = Version,
            }));
        }

        return IsOpen;
    }

    /// <summary>
    /// Exits persistence.
    /// </summary>
    /// <param name="delay">An optional delay before clean up.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool Exit(TimeSpan delay)
    {
        return Send(Command.Create(new ExitCommand()
        {
            Delay = delay,
        }));
    }

    /// <summary>
    /// Updates the current persistent state with default values for the machine, solution and project.
    /// </summary>
    /// <param name="root">The new root.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool Update(CompilationUnitSyntax root)
    {
        return Update(null, null, null, root);
    }

    /// <summary>
    /// Updates the current persistent state.
    /// </summary>
    /// <param name="deviceId">The unique ID of the device on which the caller is running, or <see langword="null"/> for the local machine.</param>
    /// <param name="solutionPath">The full path to the solution file, or <see langword="null"/> for a default solution.</param>
    /// <param name="projectPath">The full path to the project file, or <see langword="null"/> for a default project.</param>
    /// <param name="root">The new root.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool Update(string? deviceId, string? solutionPath, string? projectPath, CompilationUnitSyntax root)
    {
        if (deviceId is null)
            WindowsDeviceId = WindowsDeviceId ?? GetWindowsDeviceId();

        return Send(Command.Create(new UpdateCommand()
        {
            DeviceId = deviceId ?? WindowsDeviceId,
            SolutionPath = solutionPath,
            ProjectPath = projectPath,
            Root = root,
        }));
    }

    private static Channel? Channel;
    private static readonly DebugLogger Logger = new();
    private static string? WindowsDeviceId;
}
