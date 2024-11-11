﻿namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class FileScopedNamespaceDeclarationSyntax : BaseNamespaceDeclarationSyntax
{
    public FileScopedNamespaceDeclarationSyntax()
    {
        AttributeLists = null!;
        NamespaceKeyword = null!;
        Name = null!;
        SemicolonToken = null!;
        Externs = null!;
        Usings = null!;
        Members = null!;
        Parent = null;
    }

    public FileScopedNamespaceDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.FileScopedNamespaceDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        NamespaceKeyword = Cloner.ToToken(node.NamespaceKeyword);
        Name = NameSyntax.From(node.Name, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Externs = Cloner.ListFrom<ExternAliasDirectiveSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.ExternAliasDirectiveSyntax>(node.Externs, this);
        Usings = Cloner.ListFrom<UsingDirectiveSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax>(node.Usings, this);
        Members = Cloner.ListFrom<MemberDeclarationSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax>(node.Members, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken NamespaceKeyword { get; init; }
    public NameSyntax Name { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxList<ExternAliasDirectiveSyntax> Externs { get; init; }
    public SyntaxList<UsingDirectiveSyntax> Usings { get; init; }
    public SyntaxList<MemberDeclarationSyntax> Members { get; init; }
    public SyntaxNode? Parent { get; init; }
}
