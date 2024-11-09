namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class NamespaceDeclarationSyntax : BaseNamespaceDeclarationSyntax
{
    public NamespaceDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        NamespaceKeyword = Cloner.ToToken(node.NamespaceKeyword);
        Name = NameSyntax.From(node.Name, this);
        OpenBraceToken = Cloner.ToToken(node.OpenBraceToken);
        Externs = Cloner.ListFrom<ExternAliasDirectiveSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.ExternAliasDirectiveSyntax>(node.Externs, parent);
        Usings = Cloner.ListFrom<UsingDirectiveSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax>(node.Usings, parent);
        Members = Cloner.ListFrom<MemberDeclarationSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax>(node.Members, parent);
        CloseBraceToken = Cloner.ToToken(node.CloseBraceToken);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; }
    public SyntaxToken NamespaceKeyword { get; }
    public NameSyntax Name { get; }
    public SyntaxToken OpenBraceToken { get; }
    public SyntaxList<ExternAliasDirectiveSyntax> Externs { get; }
    public SyntaxList<UsingDirectiveSyntax> Usings { get; }
    public SyntaxList<MemberDeclarationSyntax> Members { get; }
    public SyntaxToken CloseBraceToken { get; }
    public SyntaxToken SemicolonToken { get; }
    public SyntaxNode? Parent { get; }
}
