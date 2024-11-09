namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class InterpolationAlignmentClauseSyntax : SyntaxNode
{
    public InterpolationAlignmentClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolationAlignmentClauseSyntax node, SyntaxNode? parent)
    {
        CommaToken = Cloner.ToToken(node.CommaToken);
        Value = ExpressionSyntax.From(node.Value, this);
        Parent = parent;
    }

    public SyntaxToken CommaToken { get; }
    public ExpressionSyntax Value { get; }
    public SyntaxNode? Parent { get; }
}
