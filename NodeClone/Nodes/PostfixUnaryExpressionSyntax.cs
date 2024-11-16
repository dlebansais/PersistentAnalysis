namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class PostfixUnaryExpressionSyntax : ExpressionSyntax
{
    public PostfixUnaryExpressionSyntax()
    {
        Operand = null!;
        OperatorToken = null!;
        Parent = null;
    }

    public PostfixUnaryExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.PostfixUnaryExpressionSyntax node, SyntaxNode? parent)
    {
        Operand = ExpressionSyntax.From(node.Operand, this);
        OperatorToken = Cloner.ToToken(node.OperatorToken);
        Parent = parent;
    }

    public ExpressionSyntax Operand { get; init; }
    public SyntaxToken OperatorToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Operand.AppendTo(stringBuilder);
        OperatorToken.AppendTo(stringBuilder);
    }
}
