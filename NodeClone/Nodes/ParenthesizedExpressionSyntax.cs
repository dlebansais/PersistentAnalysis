namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ParenthesizedExpressionSyntax : ExpressionSyntax
{
    public ParenthesizedExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedExpressionSyntax node, SyntaxNode? parent)
    {
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Expression = ExpressionSyntax.From(node.Expression, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken OpenParenToken { get; }
    public ExpressionSyntax Expression { get; }
    public SyntaxToken CloseParenToken { get; }
    public SyntaxNode? Parent { get; }
}
