namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class RefExpressionSyntax : ExpressionSyntax
{
    public RefExpressionSyntax()
    {
        RefKeyword = null!;
        Expression = null!;
        Parent = null;
    }

    public RefExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.RefExpressionSyntax node, SyntaxNode? parent)
    {
        RefKeyword = Cloner.ToToken(node.RefKeyword);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public SyntaxToken RefKeyword { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxNode? Parent { get; init; }
}
