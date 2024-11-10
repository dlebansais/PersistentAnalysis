namespace NodeClone;

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
}
