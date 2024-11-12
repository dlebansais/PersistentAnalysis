namespace PersistentAnalysis;

/// <summary>
/// Represents an analyzer diagnostic.
/// </summary>
/// <param name="diagnosticId">The diagnostic ID.</param>
/// <param name="diagnosticText">The diagnostic text.</param>
public class AnalyzerDiagnostic(string diagnosticId, string diagnosticText)
{
    /// <summary>
    /// Gets the diagnostic ID.
    /// </summary>
    public string DiagnosticId { get; } = diagnosticId;

    /// <summary>
    /// Gets the diagnostic text.
    /// </summary>
    public string DiagnosticText { get; } = diagnosticText;
}
