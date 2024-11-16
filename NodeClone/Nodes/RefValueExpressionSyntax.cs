namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class RefValueExpressionSyntax : ExpressionSyntax
{
    public RefValueExpressionSyntax()
    {
        Keyword = null!;
        OpenParenToken = null!;
        Expression = null!;
        Comma = null!;
        Type = null!;
        CloseParenToken = null!;
        Parent = null;
    }

    public RefValueExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.RefValueExpressionSyntax node, SyntaxNode? parent)
    {
        Keyword = Cloner.ToToken(node.Keyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Comma = Cloner.ToToken(node.Comma);
        Type = TypeSyntax.From(node.Type, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken Keyword { get; init; }
    public SyntaxToken OpenParenToken { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxToken Comma { get; init; }
    public TypeSyntax Type { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Keyword.AppendTo(stringBuilder);
        OpenParenToken.AppendTo(stringBuilder);
        Expression.AppendTo(stringBuilder);
        Comma.AppendTo(stringBuilder);
        Type.AppendTo(stringBuilder);
        CloseParenToken.AppendTo(stringBuilder);
    }
}
