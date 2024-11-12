namespace PersistentAnalysis;

using System;
using System.Collections.Generic;

/// <summary>
/// Represents arguments of <see cref="IAnalyzerApi.DiagnosticChangedEvent"/>.
/// </summary>
/// <param name="diagnostics">The collection of diagnostics.</param>
public class DiagnosticChangedEventArgs(IReadOnlyCollection<AnalyzerDiagnostic> diagnostics) : EventArgs
{
    /// <summary>
    /// Gets the collection of diagnostics.
    /// </summary>
    public IReadOnlyCollection<AnalyzerDiagnostic> Diagnostics { get; } = diagnostics;
}
