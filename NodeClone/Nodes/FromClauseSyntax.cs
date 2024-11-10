namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class FromClauseSyntax : QueryClauseSyntax
{
    public FromClauseSyntax()
    {
        FromKeyword = null!;
        Type = null!;
        Identifier = null!;
        InKeyword = null!;
        Expression = null!;
        Parent = null;
    }

    public FromClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.FromClauseSyntax node, SyntaxNode? parent)
    {
        FromKeyword = Cloner.ToToken(node.FromKeyword);
        Type = node.Type is null ? null : TypeSyntax.From(node.Type, this);
        Identifier = Cloner.ToToken(node.Identifier);
        InKeyword = Cloner.ToToken(node.InKeyword);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public SyntaxToken FromKeyword { get; init; }
    public TypeSyntax? Type { get; init; }
    public SyntaxToken Identifier { get; init; }
    public SyntaxToken InKeyword { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxNode? Parent { get; init; }
}
