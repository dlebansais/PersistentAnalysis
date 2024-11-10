namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ExpressionColonSyntax : BaseExpressionColonSyntax
{
    public ExpressionColonSyntax()
    {
        Expression = null!;
        ColonToken = null!;
        Parent = null;
    }

    public ExpressionColonSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionColonSyntax node, SyntaxNode? parent)
    {
        Expression = ExpressionSyntax.From(node.Expression, this);
        ColonToken = Cloner.ToToken(node.ColonToken);
        Parent = parent;
    }

    public ExpressionSyntax Expression { get; init; }
    public SyntaxToken ColonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
