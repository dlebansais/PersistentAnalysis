﻿namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(ClassDeclarationSyntax), typeDiscriminator: "ClassDeclarationSyntax")]
[JsonDerivedType(typeof(InterfaceDeclarationSyntax), typeDiscriminator: "InterfaceDeclarationSyntax")]
[JsonDerivedType(typeof(RecordDeclarationSyntax), typeDiscriminator: "RecordDeclarationSyntax")]
[JsonDerivedType(typeof(StructDeclarationSyntax), typeDiscriminator: "StructDeclarationSyntax")]
public abstract class TypeDeclarationSyntax : BaseTypeDeclarationSyntax
{
    public static TypeDeclarationSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax AsClassDeclarationSyntax => new ClassDeclarationSyntax(AsClassDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.InterfaceDeclarationSyntax AsInterfaceDeclarationSyntax => new InterfaceDeclarationSyntax(AsInterfaceDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.RecordDeclarationSyntax AsRecordDeclarationSyntax => new RecordDeclarationSyntax(AsRecordDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.StructDeclarationSyntax AsStructDeclarationSyntax => new StructDeclarationSyntax(AsStructDeclarationSyntax, parent),
            _ => null!,
        };
    }
}
