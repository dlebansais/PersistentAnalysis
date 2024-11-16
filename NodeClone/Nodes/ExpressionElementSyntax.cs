namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ExpressionElementSyntax : CollectionElementSyntax
{
    public ExpressionElementSyntax()
    {
        Expression = null!;
        Parent = null;
    }

    public ExpressionElementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionElementSyntax node, SyntaxNode? parent)
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
