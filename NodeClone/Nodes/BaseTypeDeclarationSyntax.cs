﻿namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonDerivedType(typeof(ClassDeclarationSyntax))]
[JsonDerivedType(typeof(InterfaceDeclarationSyntax))]
[JsonDerivedType(typeof(RecordDeclarationSyntax))]
[JsonDerivedType(typeof(StructDeclarationSyntax))]
[JsonDerivedType(typeof(EnumDeclarationSyntax))]
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
