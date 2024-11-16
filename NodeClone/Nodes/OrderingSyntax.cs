namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class OrderingSyntax : SyntaxNode
{
    public OrderingSyntax()
    {
        Expression = null!;
        AscendingOrDescendingKeyword = null!;
        Parent = null;
    }

    public OrderingSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.OrderingSyntax node, SyntaxNode? parent)
    {
        Expression = ExpressionSyntax.From(node.Expression, this);
        AscendingOrDescendingKeyword = Cloner.ToToken(node.AscendingOrDescendingKeyword);
        Parent = parent;
    }

    public ExpressionSyntax Expression { get; init; }
    public SyntaxToken AscendingOrDescendingKeyword { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Expression.AppendTo(stringBuilder);
        AscendingOrDescendingKeyword.AppendTo(stringBuilder);
    }
}
