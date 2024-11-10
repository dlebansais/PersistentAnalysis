namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class LetClauseSyntax : QueryClauseSyntax
{
    public LetClauseSyntax()
    {
        LetKeyword = null!;
        Identifier = null!;
        EqualsToken = null!;
        Expression = null!;
        Parent = null;
    }

    public LetClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.LetClauseSyntax node, SyntaxNode? parent)
    {
        LetKeyword = Cloner.ToToken(node.LetKeyword);
        Identifier = Cloner.ToToken(node.Identifier);
        EqualsToken = Cloner.ToToken(node.EqualsToken);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public SyntaxToken LetKeyword { get; init; }
    public SyntaxToken Identifier { get; init; }
    public SyntaxToken EqualsToken { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxNode? Parent { get; init; }
}
