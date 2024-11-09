namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class FromClauseSyntax : QueryClauseSyntax
{
    public FromClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.FromClauseSyntax node, SyntaxNode? parent)
    {
        FromKeyword = Cloner.ToToken(node.FromKeyword);
        Type = node.Type is null ? null : TypeSyntax.From(node.Type, this);
        Identifier = Cloner.ToToken(node.Identifier);
        InKeyword = Cloner.ToToken(node.InKeyword);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public SyntaxToken FromKeyword { get; }
    public TypeSyntax? Type { get; }
    public SyntaxToken Identifier { get; }
    public SyntaxToken InKeyword { get; }
    public ExpressionSyntax Expression { get; }
    public SyntaxNode? Parent { get; }
}
