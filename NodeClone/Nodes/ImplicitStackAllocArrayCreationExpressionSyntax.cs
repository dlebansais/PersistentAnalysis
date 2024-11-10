namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ImplicitStackAllocArrayCreationExpressionSyntax : ExpressionSyntax
{
    public ImplicitStackAllocArrayCreationExpressionSyntax()
    {
        StackAllocKeyword = null!;
        OpenBracketToken = null!;
        CloseBracketToken = null!;
        Initializer = null!;
        Parent = null;
    }

    public ImplicitStackAllocArrayCreationExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitStackAllocArrayCreationExpressionSyntax node, SyntaxNode? parent)
    {
        StackAllocKeyword = Cloner.ToToken(node.StackAllocKeyword);
        OpenBracketToken = Cloner.ToToken(node.OpenBracketToken);
        CloseBracketToken = Cloner.ToToken(node.CloseBracketToken);
        Initializer = new InitializerExpressionSyntax(node.Initializer, this);
        Parent = parent;
    }

    public SyntaxToken StackAllocKeyword { get; init; }
    public SyntaxToken OpenBracketToken { get; init; }
    public SyntaxToken CloseBracketToken { get; init; }
    public InitializerExpressionSyntax Initializer { get; init; }
    public SyntaxNode? Parent { get; init; }
}
