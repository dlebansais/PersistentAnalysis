namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class EventDeclarationSyntax : BasePropertyDeclarationSyntax
{
    public EventDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.EventDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        EventKeyword = Cloner.ToToken(node.EventKeyword);
        Type = TypeSyntax.From(node.Type, this);
        ExplicitInterfaceSpecifier = node.ExplicitInterfaceSpecifier is null ? null : new ExplicitInterfaceSpecifierSyntax(node.ExplicitInterfaceSpecifier, this);
        Identifier = Cloner.ToToken(node.Identifier);
        AccessorList = node.AccessorList is null ? null : new AccessorListSyntax(node.AccessorList, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; }
    public SyntaxToken EventKeyword { get; }
    public TypeSyntax Type { get; }
    public ExplicitInterfaceSpecifierSyntax? ExplicitInterfaceSpecifier { get; }
    public SyntaxToken Identifier { get; }
    public AccessorListSyntax? AccessorList { get; }
    public SyntaxToken SemicolonToken { get; }
    public SyntaxNode? Parent { get; }
}
