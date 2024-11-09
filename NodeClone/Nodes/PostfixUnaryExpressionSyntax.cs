namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class PostfixUnaryExpressionSyntax : ExpressionSyntax
{
    public PostfixUnaryExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.PostfixUnaryExpressionSyntax node, SyntaxNode? parent)
    {
        Operand = ExpressionSyntax.From(node.Operand, this);
        OperatorToken = Cloner.ToToken(node.OperatorToken);
        Parent = parent;
    }

    public ExpressionSyntax Operand { get; }
    public SyntaxToken OperatorToken { get; }
    public SyntaxNode? Parent { get; }
}
