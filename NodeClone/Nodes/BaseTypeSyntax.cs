﻿namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(SimpleBaseTypeSyntax), typeDiscriminator: "SimpleBaseTypeSyntax")]
[JsonDerivedType(typeof(PrimaryConstructorBaseTypeSyntax), typeDiscriminator: "PrimaryConstructorBaseTypeSyntax")]
public abstract class BaseTypeSyntax : SyntaxNode
{
    public static BaseTypeSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.BaseTypeSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.SimpleBaseTypeSyntax AsSimpleBaseTypeSyntax => new SimpleBaseTypeSyntax(AsSimpleBaseTypeSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.PrimaryConstructorBaseTypeSyntax AsPrimaryConstructorBaseTypeSyntax => new PrimaryConstructorBaseTypeSyntax(AsPrimaryConstructorBaseTypeSyntax, parent),
            _ => null!,
        };
    }
}
