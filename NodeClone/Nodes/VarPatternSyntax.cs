namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class VarPatternSyntax : PatternSyntax
{
    public VarPatternSyntax()
    {
        VarKeyword = null!;
        Designation = null!;
        Parent = null;
    }

    public VarPatternSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.VarPatternSyntax node, SyntaxNode? parent)
    {
        VarKeyword = Cloner.ToToken(node.VarKeyword);
        Designation = VariableDesignationSyntax.From(node.Designation, this);
        Parent = parent;
    }

    public SyntaxToken VarKeyword { get; init; }
    public VariableDesignationSyntax Designation { get; init; }
    public SyntaxNode? Parent { get; init; }
}
