namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ConstantPatternSyntax : PatternSyntax
{
    public ConstantPatternSyntax()
    {
        Expression = null!;
        Parent = null;
    }

    public ConstantPatternSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ConstantPatternSyntax node, SyntaxNode? parent)
    {
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public ExpressionSyntax Expression { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Expression.AppendTo(stringBuilder);
    }
}
