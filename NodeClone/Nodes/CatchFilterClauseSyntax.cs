namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class CatchFilterClauseSyntax : SyntaxNode
{
    public CatchFilterClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.CatchFilterClauseSyntax node, SyntaxNode? parent)
    {
        WhenKeyword = Cloner.ToToken(node.WhenKeyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        FilterExpression = ExpressionSyntax.From(node.FilterExpression, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken WhenKeyword { get; }
    public SyntaxToken OpenParenToken { get; }
    public ExpressionSyntax FilterExpression { get; }
    public SyntaxToken CloseParenToken { get; }
    public SyntaxNode? Parent { get; }
}
