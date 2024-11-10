namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ArrowExpressionClauseSyntax : SyntaxNode
{
    public ArrowExpressionClauseSyntax()
    {
        ArrowToken = null!;
        Expression = null!;
        Parent = null;
    }

    public ArrowExpressionClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ArrowExpressionClauseSyntax node, SyntaxNode? parent)
    {
        ArrowToken = Cloner.ToToken(node.ArrowToken);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public SyntaxToken ArrowToken { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxNode? Parent { get; init; }
}
