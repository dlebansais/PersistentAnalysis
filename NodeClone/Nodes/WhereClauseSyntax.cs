namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class WhereClauseSyntax : QueryClauseSyntax
{
    public WhereClauseSyntax()
    {
        WhereKeyword = null!;
        Condition = null!;
        Parent = null;
    }

    public WhereClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.WhereClauseSyntax node, SyntaxNode? parent)
    {
        WhereKeyword = Cloner.ToToken(node.WhereKeyword);
        Condition = ExpressionSyntax.From(node.Condition, this);
        Parent = parent;
    }

    public SyntaxToken WhereKeyword { get; init; }
    public ExpressionSyntax Condition { get; init; }
    public SyntaxNode? Parent { get; init; }
}
