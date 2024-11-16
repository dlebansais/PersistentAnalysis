namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class SelectClauseSyntax : SelectOrGroupClauseSyntax
{
    public SelectClauseSyntax()
    {
        SelectKeyword = null!;
        Expression = null!;
        Parent = null;
    }

    public SelectClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.SelectClauseSyntax node, SyntaxNode? parent)
    {
        SelectKeyword = Cloner.ToToken(node.SelectKeyword);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public SyntaxToken SelectKeyword { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        SelectKeyword.AppendTo(stringBuilder);
        Expression.AppendTo(stringBuilder);
    }
}
