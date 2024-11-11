namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class NamespaceDeclarationSyntax : BaseNamespaceDeclarationSyntax
{
    public NamespaceDeclarationSyntax()
    {
        AttributeLists = null!;
        NamespaceKeyword = null!;
        Name = null!;
        OpenBraceToken = null!;
        Externs = null!;
        Usings = null!;
        Members = null!;
        CloseBraceToken = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public NamespaceDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        NamespaceKeyword = Cloner.ToToken(node.NamespaceKeyword);
        Name = NameSyntax.From(node.Name, this);
        OpenBraceToken = Cloner.ToToken(node.OpenBraceToken);
        Externs = Cloner.ListFrom<ExternAliasDirectiveSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.ExternAliasDirectiveSyntax>(node.Externs, this);
        Usings = Cloner.ListFrom<UsingDirectiveSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax>(node.Usings, this);
        Members = Cloner.ListFrom<MemberDeclarationSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax>(node.Members, this);
        CloseBraceToken = Cloner.ToToken(node.CloseBraceToken);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken NamespaceKeyword { get; init; }
    public NameSyntax Name { get; init; }
    public SyntaxToken OpenBraceToken { get; init; }
    public SyntaxList<ExternAliasDirectiveSyntax> Externs { get; init; }
    public SyntaxList<UsingDirectiveSyntax> Usings { get; init; }
    public SyntaxList<MemberDeclarationSyntax> Members { get; init; }
    public SyntaxToken CloseBraceToken { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
