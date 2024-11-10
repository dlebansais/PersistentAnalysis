namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class InterpolationAlignmentClauseSyntax : SyntaxNode
{
    public InterpolationAlignmentClauseSyntax()
    {
        CommaToken = null!;
        Value = null!;
        Parent = null;
    }

    public InterpolationAlignmentClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolationAlignmentClauseSyntax node, SyntaxNode? parent)
    {
        CommaToken = Cloner.ToToken(node.CommaToken);
        Value = ExpressionSyntax.From(node.Value, this);
        Parent = parent;
    }

    public SyntaxToken CommaToken { get; init; }
    public ExpressionSyntax Value { get; init; }
    public SyntaxNode? Parent { get; init; }
}
