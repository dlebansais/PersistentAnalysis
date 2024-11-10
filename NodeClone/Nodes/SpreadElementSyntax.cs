namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class SpreadElementSyntax : CollectionElementSyntax
{
    public SpreadElementSyntax()
    {
        OperatorToken = null!;
        Expression = null!;
        Parent = null;
    }

    public SpreadElementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.SpreadElementSyntax node, SyntaxNode? parent)
    {
        OperatorToken = Cloner.ToToken(node.OperatorToken);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public SyntaxToken OperatorToken { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxNode? Parent { get; init; }
}
