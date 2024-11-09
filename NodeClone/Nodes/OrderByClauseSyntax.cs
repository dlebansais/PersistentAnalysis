namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class OrderByClauseSyntax : QueryClauseSyntax
{
    public OrderByClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.OrderByClauseSyntax node, SyntaxNode? parent)
    {
        OrderByKeyword = Cloner.ToToken(node.OrderByKeyword);
        Orderings = Cloner.SeparatedListFrom<OrderingSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.OrderingSyntax>(node.Orderings, parent);
        Parent = parent;
    }

    public SyntaxToken OrderByKeyword { get; }
    public SeparatedSyntaxList<OrderingSyntax> Orderings { get; }
    public SyntaxNode? Parent { get; }
}
