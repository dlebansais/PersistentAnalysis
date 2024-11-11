namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class TypeParameterSyntax : SyntaxNode
{
    public TypeParameterSyntax()
    {
        AttributeLists = null!;
        VarianceKeyword = null!;
        Identifier = null!;
        Parent = null;
    }

    public TypeParameterSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        VarianceKeyword = Cloner.ToToken(node.VarianceKeyword);
        Identifier = Cloner.ToToken(node.Identifier);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken VarianceKeyword { get; init; }
    public SyntaxToken Identifier { get; init; }
    public SyntaxNode? Parent { get; init; }
}
