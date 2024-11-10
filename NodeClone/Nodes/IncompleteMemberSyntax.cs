namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class IncompleteMemberSyntax : MemberDeclarationSyntax
{
    public IncompleteMemberSyntax()
    {
        AttributeLists = null!;
        Type = null!;
        Parent = null;
    }

    public IncompleteMemberSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.IncompleteMemberSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        Type = node.Type is null ? null : TypeSyntax.From(node.Type, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public TypeSyntax? Type { get; init; }
    public SyntaxNode? Parent { get; init; }
}
