namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(EventDeclarationSyntax), typeDiscriminator: "EventDeclarationSyntax")]
[JsonDerivedType(typeof(IndexerDeclarationSyntax), typeDiscriminator: "IndexerDeclarationSyntax")]
[JsonDerivedType(typeof(PropertyDeclarationSyntax), typeDiscriminator: "PropertyDeclarationSyntax")]
public abstract class BasePropertyDeclarationSyntax : MemberDeclarationSyntax
{
    public static BasePropertyDeclarationSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.BasePropertyDeclarationSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.EventDeclarationSyntax AsEventDeclarationSyntax => new EventDeclarationSyntax(AsEventDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.IndexerDeclarationSyntax AsIndexerDeclarationSyntax => new IndexerDeclarationSyntax(AsIndexerDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.PropertyDeclarationSyntax AsPropertyDeclarationSyntax => new PropertyDeclarationSyntax(AsPropertyDeclarationSyntax, parent),
            _ => null!,
        };
    }
}
