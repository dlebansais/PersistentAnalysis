namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class BinaryExpressionSyntax : ExpressionSyntax
{
    public BinaryExpressionSyntax()
    {
        Left = null!;
        OperatorToken = null!;
        Right = null!;
        Parent = null;
    }

    public BinaryExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.BinaryExpressionSyntax node, SyntaxNode? parent)
    {
        Left = ExpressionSyntax.From(node.Left, this);
        OperatorToken = Cloner.ToToken(node.OperatorToken);
        Right = ExpressionSyntax.From(node.Right, this);
        Parent = parent;
    }

    public ExpressionSyntax Left { get; init; }
    public SyntaxToken OperatorToken { get; init; }
    public ExpressionSyntax Right { get; init; }
    public SyntaxNode? Parent { get; init; }
}
