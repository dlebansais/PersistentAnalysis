namespace PersistentAnalysis;

using NodeClone;

internal class UpdateCommand
{
    public string? DeviceId { get; set; }
    public string? SolutionPath { get; set; }
    public string? ProjectPath { get; set; }
    public CompilationUnitSyntax? Root { get; set; }
}
