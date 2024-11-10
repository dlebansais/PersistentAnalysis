namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class MakeRefExpressionSyntax : ExpressionSyntax
{
    public MakeRefExpressionSyntax()
    {
        Keyword = null!;
        OpenParenToken = null!;
        Expression = null!;
        CloseParenToken = null!;
        Parent = null;
    }

    public MakeRefExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.MakeRefExpressionSyntax node, SyntaxNode? parent)
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
