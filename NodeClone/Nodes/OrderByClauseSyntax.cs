namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class OrderByClauseSyntax : QueryClauseSyntax
{
    public OrderByClauseSyntax()
    {
        OrderByKeyword = null!;
        Orderings = null!;
        Parent = null;
    }

    public OrderByClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.OrderByClauseSyntax node, SyntaxNode? parent)
    {
        OrderByKeyword = Cloner.ToToken(node.OrderByKeyword);
        Orderings = Cloner.SeparatedListFrom<OrderingSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.OrderingSyntax>(node.Orderings, this);
        Parent = parent;
    }

    public SyntaxToken OrderByKeyword { get; init; }
    public SeparatedSyntaxList<OrderingSyntax> Orderings { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        OrderByKeyword.AppendTo(stringBuilder);
        Orderings.AppendTo(stringBuilder);
    }
}
