namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ConditionalAccessExpressionSyntax : ExpressionSyntax
{
    public ConditionalAccessExpressionSyntax()
    {
        Expression = null!;
        OperatorToken = null!;
        WhenNotNull = null!;
        Parent = null;
    }

    public ConditionalAccessExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ConditionalAccessExpressionSyntax node, SyntaxNode? parent)
    {
        Expression = ExpressionSyntax.From(node.Expression, this);
        OperatorToken = Cloner.ToToken(node.OperatorToken);
        WhenNotNull = ExpressionSyntax.From(node.WhenNotNull, this);
        Parent = parent;
    }

    public ExpressionSyntax Expression { get; init; }
    public SyntaxToken OperatorToken { get; init; }
    public ExpressionSyntax WhenNotNull { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Expression.AppendTo(stringBuilder);
        OperatorToken.AppendTo(stringBuilder);
        WhenNotNull.AppendTo(stringBuilder);
    }
}
