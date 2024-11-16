namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class InvocationExpressionSyntax : ExpressionSyntax
{
    public InvocationExpressionSyntax()
    {
        Expression = null!;
        ArgumentList = null!;
        Parent = null;
    }

    public InvocationExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.InvocationExpressionSyntax node, SyntaxNode? parent)
    {
        Expression = ExpressionSyntax.From(node.Expression, this);
        ArgumentList = new ArgumentListSyntax(node.ArgumentList, this);
        Parent = parent;
    }

    public ExpressionSyntax Expression { get; init; }
    public ArgumentListSyntax ArgumentList { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Expression.AppendTo(stringBuilder);
        ArgumentList.AppendTo(stringBuilder);
    }
}
