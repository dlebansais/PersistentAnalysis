﻿namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(ClassDeclarationSyntax), typeDiscriminator: "ClassDeclarationSyntax")]
[JsonDerivedType(typeof(ConstructorDeclarationSyntax), typeDiscriminator: "ConstructorDeclarationSyntax")]
[JsonDerivedType(typeof(ConversionOperatorDeclarationSyntax), typeDiscriminator: "ConversionOperatorDeclarationSyntax")]
[JsonDerivedType(typeof(DelegateDeclarationSyntax), typeDiscriminator: "DelegateDeclarationSyntax")]
[JsonDerivedType(typeof(DestructorDeclarationSyntax), typeDiscriminator: "DestructorDeclarationSyntax")]
[JsonDerivedType(typeof(EnumMemberDeclarationSyntax), typeDiscriminator: "EnumMemberDeclarationSyntax")]
[JsonDerivedType(typeof(EventDeclarationSyntax), typeDiscriminator: "EventDeclarationSyntax")]
[JsonDerivedType(typeof(GlobalStatementSyntax), typeDiscriminator: "GlobalStatementSyntax")]
[JsonDerivedType(typeof(IndexerDeclarationSyntax), typeDiscriminator: "IndexerDeclarationSyntax")]
[JsonDerivedType(typeof(InterfaceDeclarationSyntax), typeDiscriminator: "InterfaceDeclarationSyntax")]
[JsonDerivedType(typeof(MethodDeclarationSyntax), typeDiscriminator: "MethodDeclarationSyntax")]
[JsonDerivedType(typeof(NamespaceDeclarationSyntax), typeDiscriminator: "NamespaceDeclarationSyntax")]
[JsonDerivedType(typeof(OperatorDeclarationSyntax), typeDiscriminator: "OperatorDeclarationSyntax")]
[JsonDerivedType(typeof(PropertyDeclarationSyntax), typeDiscriminator: "PropertyDeclarationSyntax")]
[JsonDerivedType(typeof(RecordDeclarationSyntax), typeDiscriminator: "RecordDeclarationSyntax")]
[JsonDerivedType(typeof(StructDeclarationSyntax), typeDiscriminator: "StructDeclarationSyntax")]
[JsonDerivedType(typeof(FileScopedNamespaceDeclarationSyntax), typeDiscriminator: "FileScopedNamespaceDeclarationSyntax")]
[JsonDerivedType(typeof(EnumDeclarationSyntax), typeDiscriminator: "EnumDeclarationSyntax")]
[JsonDerivedType(typeof(FieldDeclarationSyntax), typeDiscriminator: "FieldDeclarationSyntax")]
[JsonDerivedType(typeof(EventFieldDeclarationSyntax), typeDiscriminator: "EventFieldDeclarationSyntax")]
[JsonDerivedType(typeof(IncompleteMemberSyntax), typeDiscriminator: "IncompleteMemberSyntax")]
public abstract class MemberDeclarationSyntax : SyntaxNode
{
    public static MemberDeclarationSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax AsClassDeclarationSyntax => new ClassDeclarationSyntax(AsClassDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ConstructorDeclarationSyntax AsConstructorDeclarationSyntax => new ConstructorDeclarationSyntax(AsConstructorDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ConversionOperatorDeclarationSyntax AsConversionOperatorDeclarationSyntax => new ConversionOperatorDeclarationSyntax(AsConversionOperatorDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.DelegateDeclarationSyntax AsDelegateDeclarationSyntax => new DelegateDeclarationSyntax(AsDelegateDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.DestructorDeclarationSyntax AsDestructorDeclarationSyntax => new DestructorDeclarationSyntax(AsDestructorDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax AsEnumMemberDeclarationSyntax => new EnumMemberDeclarationSyntax(AsEnumMemberDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.EventDeclarationSyntax AsEventDeclarationSyntax => new EventDeclarationSyntax(AsEventDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax AsGlobalStatementSyntax => new GlobalStatementSyntax(AsGlobalStatementSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.IndexerDeclarationSyntax AsIndexerDeclarationSyntax => new IndexerDeclarationSyntax(AsIndexerDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.InterfaceDeclarationSyntax AsInterfaceDeclarationSyntax => new InterfaceDeclarationSyntax(AsInterfaceDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.MethodDeclarationSyntax AsMethodDeclarationSyntax => new MethodDeclarationSyntax(AsMethodDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax AsNamespaceDeclarationSyntax => new NamespaceDeclarationSyntax(AsNamespaceDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.OperatorDeclarationSyntax AsOperatorDeclarationSyntax => new OperatorDeclarationSyntax(AsOperatorDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.PropertyDeclarationSyntax AsPropertyDeclarationSyntax => new PropertyDeclarationSyntax(AsPropertyDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.RecordDeclarationSyntax AsRecordDeclarationSyntax => new RecordDeclarationSyntax(AsRecordDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.StructDeclarationSyntax AsStructDeclarationSyntax => new StructDeclarationSyntax(AsStructDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.FileScopedNamespaceDeclarationSyntax AsFileScopedNamespaceDeclarationSyntax => new FileScopedNamespaceDeclarationSyntax(AsFileScopedNamespaceDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax AsEnumDeclarationSyntax => new EnumDeclarationSyntax(AsEnumDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.FieldDeclarationSyntax AsFieldDeclarationSyntax => new FieldDeclarationSyntax(AsFieldDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.EventFieldDeclarationSyntax AsEventFieldDeclarationSyntax => new EventFieldDeclarationSyntax(AsEventFieldDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.IncompleteMemberSyntax AsIncompleteMemberSyntax => new IncompleteMemberSyntax(AsIncompleteMemberSyntax, parent),
            _ => null!,
        };
    }
}
