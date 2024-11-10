namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class CastExpressionSyntax : ExpressionSyntax
{
    public CastExpressionSyntax()
    {
        OpenParenToken = null!;
        Type = null!;
        CloseParenToken = null!;
        Expression = null!;
        Parent = null;
    }

    public CastExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.CastExpressionSyntax node, SyntaxNode? parent)
    {
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Type = TypeSyntax.From(node.Type, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public SyntaxToken OpenParenToken { get; init; }
    public TypeSyntax Type { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxNode? Parent { get; init; }
}
