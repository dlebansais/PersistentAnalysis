namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ImplicitArrayCreationExpressionSyntax : ExpressionSyntax
{
    public ImplicitArrayCreationExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitArrayCreationExpressionSyntax node, SyntaxNode? parent)
    {
        NewKeyword = Cloner.ToToken(node.NewKeyword);
        OpenBracketToken = Cloner.ToToken(node.OpenBracketToken);
        CloseBracketToken = Cloner.ToToken(node.CloseBracketToken);
        Initializer = new InitializerExpressionSyntax(node.Initializer, this);
        Parent = parent;
    }

    public SyntaxToken NewKeyword { get; }
    public SyntaxToken OpenBracketToken { get; }
    public SyntaxToken CloseBracketToken { get; }
    public InitializerExpressionSyntax Initializer { get; }
    public SyntaxNode? Parent { get; }
}
