namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class DeclarationExpressionSyntax : ExpressionSyntax
{
    public DeclarationExpressionSyntax()
    {
        Type = null!;
        Designation = null!;
        Parent = null;
    }

    public DeclarationExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.DeclarationExpressionSyntax node, SyntaxNode? parent)
    {
        Type = TypeSyntax.From(node.Type, this);
        Designation = VariableDesignationSyntax.From(node.Designation, this);
        Parent = parent;
    }

    public TypeSyntax Type { get; init; }
    public VariableDesignationSyntax Designation { get; init; }
    public SyntaxNode? Parent { get; init; }
}
