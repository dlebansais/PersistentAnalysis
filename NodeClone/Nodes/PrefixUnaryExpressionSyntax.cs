namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class PrefixUnaryExpressionSyntax : ExpressionSyntax
{
    public PrefixUnaryExpressionSyntax()
    {
        OperatorToken = null!;
        Operand = null!;
        Parent = null;
    }

    public PrefixUnaryExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.PrefixUnaryExpressionSyntax node, SyntaxNode? parent)
    {
        OperatorToken = Cloner.ToToken(node.OperatorToken);
        Operand = ExpressionSyntax.From(node.Operand, this);
        Parent = parent;
    }

    public SyntaxToken OperatorToken { get; init; }
    public ExpressionSyntax Operand { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        OperatorToken.AppendTo(stringBuilder);
        Operand.AppendTo(stringBuilder);
    }
}
