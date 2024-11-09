namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class TypeParameterSyntax : SyntaxNode
{
    public TypeParameterSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        VarianceKeyword = Cloner.ToToken(node.VarianceKeyword);
        Identifier = Cloner.ToToken(node.Identifier);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; }
    public SyntaxToken VarianceKeyword { get; }
    public SyntaxToken Identifier { get; }
    public SyntaxNode? Parent { get; }
}
