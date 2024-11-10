namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class GroupClauseSyntax : SelectOrGroupClauseSyntax
{
    public GroupClauseSyntax()
    {
        GroupKeyword = null!;
        GroupExpression = null!;
        ByKeyword = null!;
        ByExpression = null!;
        Parent = null;
    }

    public GroupClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.GroupClauseSyntax node, SyntaxNode? parent)
    {
        GroupKeyword = Cloner.ToToken(node.GroupKeyword);
        GroupExpression = ExpressionSyntax.From(node.GroupExpression, this);
        ByKeyword = Cloner.ToToken(node.ByKeyword);
        ByExpression = ExpressionSyntax.From(node.ByExpression, this);
        Parent = parent;
    }

    public SyntaxToken GroupKeyword { get; init; }
    public ExpressionSyntax GroupExpression { get; init; }
    public SyntaxToken ByKeyword { get; init; }
    public ExpressionSyntax ByExpression { get; init; }
    public SyntaxNode? Parent { get; init; }
}
