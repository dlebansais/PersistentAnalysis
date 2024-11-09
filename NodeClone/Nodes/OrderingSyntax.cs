﻿namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class OrderingSyntax : SyntaxNode
{
    public OrderingSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.OrderingSyntax node, SyntaxNode? parent)
    {
        Expression = ExpressionSyntax.From(node.Expression, this);
        AscendingOrDescendingKeyword = Cloner.ToToken(node.AscendingOrDescendingKeyword);
        Parent = parent;
    }

    public ExpressionSyntax Expression { get; }
    public SyntaxToken AscendingOrDescendingKeyword { get; }
    public SyntaxNode? Parent { get; }
}
