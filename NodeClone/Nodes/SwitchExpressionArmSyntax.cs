namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class SwitchExpressionArmSyntax : SyntaxNode
{
    public SwitchExpressionArmSyntax()
    {
        Pattern = null!;
        WhenClause = null!;
        EqualsGreaterThanToken = null!;
        Expression = null!;
        Parent = null;
    }

    public SwitchExpressionArmSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.SwitchExpressionArmSyntax node, SyntaxNode? parent)
    {
        Pattern = PatternSyntax.From(node.Pattern, this);
        WhenClause = node.WhenClause is null ? null : new WhenClauseSyntax(node.WhenClause, this);
        EqualsGreaterThanToken = Cloner.ToToken(node.EqualsGreaterThanToken);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public PatternSyntax Pattern { get; init; }
    public WhenClauseSyntax? WhenClause { get; init; }
    public SyntaxToken EqualsGreaterThanToken { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxNode? Parent { get; init; }
}
