namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class IsPatternExpressionSyntax : ExpressionSyntax
{
    public IsPatternExpressionSyntax()
    {
        Expression = null!;
        IsKeyword = null!;
        Pattern = null!;
        Parent = null;
    }

    public IsPatternExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.IsPatternExpressionSyntax node, SyntaxNode? parent)
    {
        Expression = ExpressionSyntax.From(node.Expression, this);
        IsKeyword = Cloner.ToToken(node.IsKeyword);
        Pattern = PatternSyntax.From(node.Pattern, this);
        Parent = parent;
    }

    public ExpressionSyntax Expression { get; init; }
    public SyntaxToken IsKeyword { get; init; }
    public PatternSyntax Pattern { get; init; }
    public SyntaxNode? Parent { get; init; }
}
