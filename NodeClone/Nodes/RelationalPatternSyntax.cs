namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class RelationalPatternSyntax : PatternSyntax
{
    public RelationalPatternSyntax()
    {
        OperatorToken = null!;
        Expression = null!;
        Parent = null;
    }

    public RelationalPatternSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.RelationalPatternSyntax node, SyntaxNode? parent)
    {
        OperatorToken = Cloner.ToToken(node.OperatorToken);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public SyntaxToken OperatorToken { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        OperatorToken.AppendTo(stringBuilder);
        Expression.AppendTo(stringBuilder);
    }
}
