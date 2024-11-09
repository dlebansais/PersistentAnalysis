namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ImplicitStackAllocArrayCreationExpressionSyntax : ExpressionSyntax
{
    public ImplicitStackAllocArrayCreationExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitStackAllocArrayCreationExpressionSyntax node, SyntaxNode? parent)
    {
        StackAllocKeyword = Cloner.ToToken(node.StackAllocKeyword);
        OpenBracketToken = Cloner.ToToken(node.OpenBracketToken);
        CloseBracketToken = Cloner.ToToken(node.CloseBracketToken);
        Initializer = new InitializerExpressionSyntax(node.Initializer, this);
        Parent = parent;
    }

    public SyntaxToken StackAllocKeyword { get; }
    public SyntaxToken OpenBracketToken { get; }
    public SyntaxToken CloseBracketToken { get; }
    public InitializerExpressionSyntax Initializer { get; }
    public SyntaxNode? Parent { get; }
}
