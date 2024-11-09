﻿namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class PredefinedTypeSyntax : TypeSyntax
{
    public PredefinedTypeSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.PredefinedTypeSyntax node, SyntaxNode? parent)
    {
        Keyword = Cloner.ToToken(node.Keyword);
        Parent = parent;
    }

    public SyntaxToken Keyword { get; }
    public SyntaxNode? Parent { get; }
}
