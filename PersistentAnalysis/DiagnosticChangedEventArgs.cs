namespace PersistentAnalysis;

using System;
using System.Collections.Generic;

/// <summary>
/// Represents arguments of <see cref="IAnalyzerApi.DiagnosticChangedEvent"/>.
/// </summary>
public class DiagnosticChangedEventArgs(IReadOnlyCollection<IAnalyzerDiagnostic> diagnostics) : EventArgs
{
    /// <summary>
    /// Gets the collection of diagnostics.
    /// </summary>
    public IReadOnlyCollection<IAnalyzerDiagnostic> Diagnostics { get; } = diagnostics;
}
