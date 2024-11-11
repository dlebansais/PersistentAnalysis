namespace SampleAnalyzer;

using System;
using NodeClone;
using PersistentAnalysis;

/// <summary>
/// Represents a sample analyzer API.
/// </summary>
public class SampleAnalyzerApi : IAnalyzerApi
{
    /// <inheritdoc />
    public void Update(CompilationUnitSyntax root)
    {
        Diagnostics.Clear();
        Diagnostics.Add(new SampleAnalyzerDiagnostic("FOO1234", "Foo"));

        DiagnosticChangedEvent?.Invoke(this, new DiagnosticChangedEventArgs(Diagnostics.AsReadOnly()));
    }

    /// <inheritdoc />
    public event EventHandler<DiagnosticChangedEventArgs>? DiagnosticChangedEvent;

    private readonly AnalyzerDiagnosticCollection Diagnostics = new();
}
