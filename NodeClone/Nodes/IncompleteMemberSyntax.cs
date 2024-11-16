namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class IncompleteMemberSyntax : MemberDeclarationSyntax
{
    public IncompleteMemberSyntax()
    {
        AttributeLists = null!;
        Modifiers = null!;
        Type = null!;
        Parent = null;
    }

    public IncompleteMemberSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.IncompleteMemberSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        Modifiers = Cloner.ToTokenList(node.Modifiers);
        Type = node.Type is null ? null : TypeSyntax.From(node.Type, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxTokenList Modifiers { get; init; }
    public TypeSyntax? Type { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        AttributeLists.AppendTo(stringBuilder);
        Modifiers.AppendTo(stringBuilder);
        Type?.AppendTo(stringBuilder);
    }
}
