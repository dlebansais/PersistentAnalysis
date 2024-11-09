﻿namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class FunctionPointerUnmanagedCallingConventionSyntax : SyntaxNode
{
    public FunctionPointerUnmanagedCallingConventionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.FunctionPointerUnmanagedCallingConventionSyntax node, SyntaxNode? parent)
    {
        Name = Cloner.ToToken(node.Name);
        Parent = parent;
    }

    public SyntaxToken Name { get; }
    public SyntaxNode? Parent { get; }
}
