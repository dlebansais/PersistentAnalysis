﻿namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ImplicitArrayCreationExpressionSyntax : ExpressionSyntax
{
    public ImplicitArrayCreationExpressionSyntax()
    {
        NewKeyword = null!;
        OpenBracketToken = null!;
        CloseBracketToken = null!;
        Initializer = null!;
        Parent = null;
    }

    public ImplicitArrayCreationExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitArrayCreationExpressionSyntax node, SyntaxNode? parent)
    {
        NewKeyword = Cloner.ToToken(node.NewKeyword);
        OpenBracketToken = Cloner.ToToken(node.OpenBracketToken);
        CloseBracketToken = Cloner.ToToken(node.CloseBracketToken);
        Initializer = new InitializerExpressionSyntax(node.Initializer, this);
        Parent = parent;
    }

    public SyntaxToken NewKeyword { get; init; }
    public SyntaxToken OpenBracketToken { get; init; }
    public SyntaxToken CloseBracketToken { get; init; }
    public InitializerExpressionSyntax Initializer { get; init; }
    public SyntaxNode? Parent { get; init; }
}
