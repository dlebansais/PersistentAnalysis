namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class LetClauseSyntax : QueryClauseSyntax
{
    public LetClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.LetClauseSyntax node, SyntaxNode? parent)
    {
        LetKeyword = Cloner.ToToken(node.LetKeyword);
        Identifier = Cloner.ToToken(node.Identifier);
        EqualsToken = Cloner.ToToken(node.EqualsToken);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public SyntaxToken LetKeyword { get; }
    public SyntaxToken Identifier { get; }
    public SyntaxToken EqualsToken { get; }
    public ExpressionSyntax Expression { get; }
    public SyntaxNode? Parent { get; }
}
