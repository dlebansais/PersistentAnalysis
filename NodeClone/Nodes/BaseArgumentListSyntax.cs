﻿namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(BracketedArgumentListSyntax), typeDiscriminator: "BracketedArgumentListSyntax")]
[JsonDerivedType(typeof(ArgumentListSyntax), typeDiscriminator: "ArgumentListSyntax")]
public abstract class BaseArgumentListSyntax : SyntaxNode
{
    public static BaseArgumentListSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.BaseArgumentListSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.BracketedArgumentListSyntax AsBracketedArgumentListSyntax => new BracketedArgumentListSyntax(AsBracketedArgumentListSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentListSyntax AsArgumentListSyntax => new ArgumentListSyntax(AsArgumentListSyntax, parent),
            _ => null!,
        };
    }
}
