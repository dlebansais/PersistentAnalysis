namespace PersistentAnalysis;

/// <summary>
/// Represents a type implementing a diagnostic.
/// </summary>
public interface IAnalyzerDiagnostic
{
    /// <summary>
    /// Gets the diagnostic ID.
    /// </summary>
    public string DiagnosticId { get; }

    /// <summary>
    /// Gets the diagnostic text.
    /// </summary>
    public string DiagnosticText { get; }
}
