namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class StackAllocArrayCreationExpressionSyntax : ExpressionSyntax
{
    public StackAllocArrayCreationExpressionSyntax()
    {
        StackAllocKeyword = null!;
        Type = null!;
        Initializer = null!;
        Parent = null;
    }

    public StackAllocArrayCreationExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.StackAllocArrayCreationExpressionSyntax node, SyntaxNode? parent)
    {
        StackAllocKeyword = Cloner.ToToken(node.StackAllocKeyword);
        Type = TypeSyntax.From(node.Type, this);
        Initializer = node.Initializer is null ? null : new InitializerExpressionSyntax(node.Initializer, this);
        Parent = parent;
    }

    public SyntaxToken StackAllocKeyword { get; init; }
    public TypeSyntax Type { get; init; }
    public InitializerExpressionSyntax? Initializer { get; init; }
    public SyntaxNode? Parent { get; init; }
}
