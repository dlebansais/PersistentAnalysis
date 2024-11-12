namespace PersistentAnalysis;

using System;
using System.Text.Json.Serialization;

/// <summary>
/// Represents the Exit command.
/// </summary>
/// <param name="delay">The delay before exiting.</param>
[method: JsonConstructor]
internal class ExitCommand(TimeSpan delay)
{
    /// <summary>
    /// Gets the delay before exiting.
    /// </summary>
    public TimeSpan Delay { get; } = delay;
}
