namespace PersistentAnalysis;

using System.Text.Json.Serialization;
using NodeClone;

/// <summary>
/// Represents the Update command.
/// </summary>
/// <param name="deviceId">The device ID. <see langword="null"/> for the local machine.</param>
/// <param name="solutionPath">The solution path.</param>
/// <param name="projectPath">The project path.</param>
/// <param name="root">The root to update.</param>
[method: JsonConstructor]
internal class UpdateCommand(string? deviceId, string? solutionPath, string? projectPath, CompilationUnitSyntax? root)
{
    /// <summary>
    /// Gets the device ID. <see langword="null"/> for the local machine.
    /// </summary>
    public string? DeviceId { get; } = deviceId;

    /// <summary>
    /// Gets the solution path.
    /// </summary>
    public string? SolutionPath { get; } = solutionPath;

    /// <summary>
    /// Gets the project path.
    /// </summary>
    public string? ProjectPath { get; } = projectPath;

    /// <summary>
    /// Gets the root to update.
    /// </summary>
    public CompilationUnitSyntax? Root { get; } = root;
}
