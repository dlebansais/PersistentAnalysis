namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonDerivedType(typeof(NamespaceDeclarationSyntax))]
[JsonDerivedType(typeof(FileScopedNamespaceDeclarationSyntax))]
public abstract class BaseNamespaceDeclarationSyntax : MemberDeclarationSyntax
{
    public static BaseNamespaceDeclarationSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.BaseNamespaceDeclarationSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax AsNamespaceDeclarationSyntax => new NamespaceDeclarationSyntax(AsNamespaceDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.FileScopedNamespaceDeclarationSyntax AsFileScopedNamespaceDeclarationSyntax => new FileScopedNamespaceDeclarationSyntax(AsFileScopedNamespaceDeclarationSyntax, parent),
            _ => null!,
        };
    }
}
