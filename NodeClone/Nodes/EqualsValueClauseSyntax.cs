namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class EqualsValueClauseSyntax : SyntaxNode
{
    public EqualsValueClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.EqualsValueClauseSyntax node, SyntaxNode? parent)
    {
        EqualsToken = Cloner.ToToken(node.EqualsToken);
        Value = ExpressionSyntax.From(node.Value, this);
        Parent = parent;
    }

    public SyntaxToken EqualsToken { get; }
    public ExpressionSyntax Value { get; }
    public SyntaxNode? Parent { get; }
}
