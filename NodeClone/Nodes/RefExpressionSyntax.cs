namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class RefExpressionSyntax : ExpressionSyntax
{
    public RefExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.RefExpressionSyntax node, SyntaxNode? parent)
    {
        RefKeyword = Cloner.ToToken(node.RefKeyword);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public SyntaxToken RefKeyword { get; }
    public ExpressionSyntax Expression { get; }
    public SyntaxNode? Parent { get; }
}
