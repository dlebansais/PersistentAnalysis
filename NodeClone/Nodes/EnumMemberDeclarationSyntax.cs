namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class EnumMemberDeclarationSyntax : MemberDeclarationSyntax
{
    public EnumMemberDeclarationSyntax()
    {
        AttributeLists = null!;
        Identifier = null!;
        EqualsValue = null!;
        Parent = null;
    }

    public EnumMemberDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        Identifier = Cloner.ToToken(node.Identifier);
        EqualsValue = node.EqualsValue is null ? null : new EqualsValueClauseSyntax(node.EqualsValue, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken Identifier { get; init; }
    public EqualsValueClauseSyntax? EqualsValue { get; init; }
    public SyntaxNode? Parent { get; init; }
}
