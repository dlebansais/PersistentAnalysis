namespace PersistentAnalysis;

using System;
using System.Collections.Generic;
using NodeClone;

/// <summary>
/// Represents a type implementing the analysis API.
/// </summary>
public interface IAnalyzerApi
{
    /// <summary>
    /// Updates the analyzer with a new root.
    /// </summary>
    /// <param name="root">The new root.</param>
    void Update(CompilationUnitSyntax root);

    /// <summary>
    /// The event raised when a diagnostic has changed.
    /// </summary>
    event EventHandler<DiagnosticChangedEventArgs> DiagnosticChangedEvent;
}
