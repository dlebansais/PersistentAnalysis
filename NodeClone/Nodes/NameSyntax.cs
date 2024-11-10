namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(AliasQualifiedNameSyntax), typeDiscriminator: "AliasQualifiedNameSyntax")]
[JsonDerivedType(typeof(GenericNameSyntax), typeDiscriminator: "GenericNameSyntax")]
[JsonDerivedType(typeof(IdentifierNameSyntax), typeDiscriminator: "IdentifierNameSyntax")]
[JsonDerivedType(typeof(QualifiedNameSyntax), typeDiscriminator: "QualifiedNameSyntax")]
public abstract class NameSyntax : TypeSyntax
{
    public static NameSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.NameSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.AliasQualifiedNameSyntax AsAliasQualifiedNameSyntax => new AliasQualifiedNameSyntax(AsAliasQualifiedNameSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.GenericNameSyntax AsGenericNameSyntax => new GenericNameSyntax(AsGenericNameSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax AsIdentifierNameSyntax => new IdentifierNameSyntax(AsIdentifierNameSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.QualifiedNameSyntax AsQualifiedNameSyntax => new QualifiedNameSyntax(AsQualifiedNameSyntax, parent),
            _ => null!,
        };
    }
}
