namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class CheckedExpressionSyntax : ExpressionSyntax
{
    public CheckedExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.CheckedExpressionSyntax node, SyntaxNode? parent)
    {
        Keyword = Cloner.ToToken(node.Keyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Expression = ExpressionSyntax.From(node.Expression, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken Keyword { get; }
    public SyntaxToken OpenParenToken { get; }
    public ExpressionSyntax Expression { get; }
    public SyntaxToken CloseParenToken { get; }
    public SyntaxNode? Parent { get; }
}
