namespace PersistentAnalysis;

using System.Text.Json.Serialization;

/// <summary>
/// Represents the Init command.
/// </summary>
/// <param name="clientGuid">The client unique ID.</param>
/// <param name="version">The client version.</param>
/// <param name="analyzerFileName">The analyzer file name.</param>
[method: JsonConstructor]
internal class InitCommand(string? clientGuid, string? version, string? analyzerFileName)
{
    /// <summary>
    /// Gets the client unique ID.
    /// </summary>
    public string? ClientGuid { get; } = clientGuid;

    /// <summary>
    /// Gets the client version.
    /// </summary>
    public string? Version { get; } = version;

    /// <summary>
    /// Gets the analyzer file name.
    /// </summary>
    public string? AnalyzerFileName { get; } = analyzerFileName;
}
