namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class QueryExpressionSyntax : ExpressionSyntax
{
    public QueryExpressionSyntax()
    {
        FromClause = null!;
        Body = null!;
        Parent = null;
    }

    public QueryExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.QueryExpressionSyntax node, SyntaxNode? parent)
    {
        FromClause = new FromClauseSyntax(node.FromClause, this);
        Body = new QueryBodySyntax(node.Body, this);
        Parent = parent;
    }

    public FromClauseSyntax FromClause { get; init; }
    public QueryBodySyntax Body { get; init; }
    public SyntaxNode? Parent { get; init; }
}
