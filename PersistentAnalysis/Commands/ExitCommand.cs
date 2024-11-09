namespace PersistentAnalysis;

using System;

/// <summary>
/// Represents the Exit command.
/// </summary>
internal class ExitCommand(TimeSpan delay)
{
    /// <summary>
    /// Gets the delay before exiting.
    /// </summary>
    public TimeSpan Delay { get; } = delay;
}
