namespace PersistentAnalysis;

/// <summary>
/// Represents the Init command.
/// </summary>
/// <param name="clientGuid">The client unique ID.</param>
/// <param name="version">The client version.</param>
internal class InitCommand(string? clientGuid, string? version)
{
    /// <summary>
    /// Gets the client unique ID.
    /// </summary>
    public string? ClientGuid { get; } = clientGuid;

    /// <summary>
    /// Gets the client version.
    /// </summary>
    public string? Version { get; } = version;
}
