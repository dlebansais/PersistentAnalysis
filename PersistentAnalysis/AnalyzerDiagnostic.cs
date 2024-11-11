namespace PersistentAnalysis;

/// <summary>
/// Represents an analyzer diagnostic.
/// </summary>
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
