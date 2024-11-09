namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class RefValueExpressionSyntax : ExpressionSyntax
{
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

    public SyntaxToken Keyword { get; }
    public SyntaxToken OpenParenToken { get; }
    public ExpressionSyntax Expression { get; }
    public SyntaxToken Comma { get; }
    public TypeSyntax Type { get; }
    public SyntaxToken CloseParenToken { get; }
    public SyntaxNode? Parent { get; }
}
