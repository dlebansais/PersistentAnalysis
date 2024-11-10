namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class CatchFilterClauseSyntax : SyntaxNode
{
    public CatchFilterClauseSyntax()
    {
        WhenKeyword = null!;
        OpenParenToken = null!;
        FilterExpression = null!;
        CloseParenToken = null!;
        Parent = null;
    }

    public CatchFilterClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.CatchFilterClauseSyntax node, SyntaxNode? parent)
    {
        WhenKeyword = Cloner.ToToken(node.WhenKeyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        FilterExpression = ExpressionSyntax.From(node.FilterExpression, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken WhenKeyword { get; init; }
    public SyntaxToken OpenParenToken { get; init; }
    public ExpressionSyntax FilterExpression { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
