namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ArrowExpressionClauseSyntax : SyntaxNode
{
    public ArrowExpressionClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ArrowExpressionClauseSyntax node, SyntaxNode? parent)
    {
        ArrowToken = Cloner.ToToken(node.ArrowToken);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public SyntaxToken ArrowToken { get; }
    public ExpressionSyntax Expression { get; }
    public SyntaxNode? Parent { get; }
}
