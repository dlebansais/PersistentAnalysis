namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ThrowExpressionSyntax : ExpressionSyntax
{
    public ThrowExpressionSyntax()
    {
        ThrowKeyword = null!;
        Expression = null!;
        Parent = null;
    }

    public ThrowExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ThrowExpressionSyntax node, SyntaxNode? parent)
    {
        ThrowKeyword = Cloner.ToToken(node.ThrowKeyword);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public SyntaxToken ThrowKeyword { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        ThrowKeyword.AppendTo(stringBuilder);
        Expression.AppendTo(stringBuilder);
    }
}
