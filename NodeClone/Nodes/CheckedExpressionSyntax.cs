namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class CheckedExpressionSyntax : ExpressionSyntax
{
    public CheckedExpressionSyntax()
    {
        Keyword = null!;
        OpenParenToken = null!;
        Expression = null!;
        CloseParenToken = null!;
        Parent = null;
    }

    public CheckedExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.CheckedExpressionSyntax node, SyntaxNode? parent)
    {
        Keyword = Cloner.ToToken(node.Keyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Expression = ExpressionSyntax.From(node.Expression, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken Keyword { get; init; }
    public SyntaxToken OpenParenToken { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
