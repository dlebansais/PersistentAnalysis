﻿namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(ImplicitObjectCreationExpressionSyntax), typeDiscriminator: "ImplicitObjectCreationExpressionSyntax")]
[JsonDerivedType(typeof(ObjectCreationExpressionSyntax), typeDiscriminator: "ObjectCreationExpressionSyntax")]
public abstract class BaseObjectCreationExpressionSyntax : ExpressionSyntax
{
    public static BaseObjectCreationExpressionSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.BaseObjectCreationExpressionSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitObjectCreationExpressionSyntax AsImplicitObjectCreationExpressionSyntax => new ImplicitObjectCreationExpressionSyntax(AsImplicitObjectCreationExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ObjectCreationExpressionSyntax AsObjectCreationExpressionSyntax => new ObjectCreationExpressionSyntax(AsObjectCreationExpressionSyntax, parent),
            _ => null!,
        };
    }
}
