namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class AwaitExpressionSyntax : ExpressionSyntax
{
    public AwaitExpressionSyntax()
    {
        AwaitKeyword = null!;
        Expression = null!;
        Parent = null;
    }

    public AwaitExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.AwaitExpressionSyntax node, SyntaxNode? parent)
    {
        AwaitKeyword = Cloner.ToToken(node.AwaitKeyword);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public SyntaxToken AwaitKeyword { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        AwaitKeyword.AppendTo(stringBuilder);
        Expression.AppendTo(stringBuilder);
    }
}
