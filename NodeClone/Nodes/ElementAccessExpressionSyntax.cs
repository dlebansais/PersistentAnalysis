namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ElementAccessExpressionSyntax : ExpressionSyntax
{
    public ElementAccessExpressionSyntax()
    {
        Expression = null!;
        ArgumentList = null!;
        Parent = null;
    }

    public ElementAccessExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ElementAccessExpressionSyntax node, SyntaxNode? parent)
    {
        Expression = ExpressionSyntax.From(node.Expression, this);
        ArgumentList = new BracketedArgumentListSyntax(node.ArgumentList, this);
        Parent = parent;
    }

    public ExpressionSyntax Expression { get; init; }
    public BracketedArgumentListSyntax ArgumentList { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Expression.AppendTo(stringBuilder);
        ArgumentList.AppendTo(stringBuilder);
    }
}
