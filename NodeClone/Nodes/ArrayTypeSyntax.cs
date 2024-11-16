namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ArrayTypeSyntax : TypeSyntax
{
    public ArrayTypeSyntax()
    {
        ElementType = null!;
        RankSpecifiers = null!;
        Parent = null;
    }

    public ArrayTypeSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ArrayTypeSyntax node, SyntaxNode? parent)
    {
        ElementType = TypeSyntax.From(node.ElementType, this);
        RankSpecifiers = Cloner.ListFrom<ArrayRankSpecifierSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.ArrayRankSpecifierSyntax>(node.RankSpecifiers, this);
        Parent = parent;
    }

    public TypeSyntax ElementType { get; init; }
    public SyntaxList<ArrayRankSpecifierSyntax> RankSpecifiers { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        ElementType.AppendTo(stringBuilder);
        RankSpecifiers.AppendTo(stringBuilder);
    }
}
