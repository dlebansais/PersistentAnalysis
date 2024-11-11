namespace SampleAnalyzer;

using PersistentAnalysis;

/// <summary>
/// Represents a sample analyzer diagnostic.
/// </summary>
public class SampleAnalyzerDiagnostic(string diagnosticId, string diagnosticText) : IAnalyzerDiagnostic
{
    /// <inheritdoc />
    public string DiagnosticId { get; } = diagnosticId;

    /// <inheritdoc />
    public string DiagnosticText { get; } = diagnosticText;
}
