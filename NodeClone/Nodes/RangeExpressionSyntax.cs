namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class RangeExpressionSyntax : ExpressionSyntax
{
    public RangeExpressionSyntax()
    {
        LeftOperand = null!;
        OperatorToken = null!;
        RightOperand = null!;
        Parent = null;
    }

    public RangeExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.RangeExpressionSyntax node, SyntaxNode? parent)
    {
        LeftOperand = node.LeftOperand is null ? null : ExpressionSyntax.From(node.LeftOperand, this);
        OperatorToken = Cloner.ToToken(node.OperatorToken);
        RightOperand = node.RightOperand is null ? null : ExpressionSyntax.From(node.RightOperand, this);
        Parent = parent;
    }

    public ExpressionSyntax? LeftOperand { get; init; }
    public SyntaxToken OperatorToken { get; init; }
    public ExpressionSyntax? RightOperand { get; init; }
    public SyntaxNode? Parent { get; init; }
}
