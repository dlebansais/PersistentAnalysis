namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(ClassDeclarationSyntax), typeDiscriminator: "ClassDeclarationSyntax")]
[JsonDerivedType(typeof(InterfaceDeclarationSyntax), typeDiscriminator: "InterfaceDeclarationSyntax")]
[JsonDerivedType(typeof(RecordDeclarationSyntax), typeDiscriminator: "RecordDeclarationSyntax")]
[JsonDerivedType(typeof(StructDeclarationSyntax), typeDiscriminator: "StructDeclarationSyntax")]
[JsonDerivedType(typeof(EnumDeclarationSyntax), typeDiscriminator: "EnumDeclarationSyntax")]
public abstract class BaseTypeDeclarationSyntax : MemberDeclarationSyntax
{
    public static BaseTypeDeclarationSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.BaseTypeDeclarationSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax AsClassDeclarationSyntax => new ClassDeclarationSyntax(AsClassDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.InterfaceDeclarationSyntax AsInterfaceDeclarationSyntax => new InterfaceDeclarationSyntax(AsInterfaceDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.RecordDeclarationSyntax AsRecordDeclarationSyntax => new RecordDeclarationSyntax(AsRecordDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.StructDeclarationSyntax AsStructDeclarationSyntax => new StructDeclarationSyntax(AsStructDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax AsEnumDeclarationSyntax => new EnumDeclarationSyntax(AsEnumDeclarationSyntax, parent),
            _ => null!,
        };
    }
}
