namespace SampleAnalyzer;

using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PersistentAnalysis;

/// <summary>
/// Represents a sample analyzer API.
/// </summary>
public class SampleAnalyzerApi : IAnalyzerApi
{
    /// <inheritdoc />
    public void Update(NodeClone.CompilationUnitSyntax root)
    {
        CompilationUnitSyntax Root = NodeClone.Cloner.Reconstruct(root);

        Diagnostics.Clear();
        Diagnostics.Add(new AnalyzerDiagnostic("FOO1234", "Foo"));

        DiagnosticChangedEvent?.Invoke(this, new DiagnosticChangedEventArgs(Diagnostics.AsReadOnly()));
    }

    /// <inheritdoc />
    public event EventHandler<DiagnosticChangedEventArgs>? DiagnosticChangedEvent;

    private readonly AnalyzerDiagnosticCollection Diagnostics = new();
    private bool disposedValue;

    /// <summary>
    /// Disposes of managed and unmanaged resources.
    /// </summary>
    /// <param name="disposing"><see langword="True"/> if the method should dispose of resources; Otherwise, <see langword="false"/>.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // Nothing to dispose of in this sample.
            }

            disposedValue = true;
        }
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
