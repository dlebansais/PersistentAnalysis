namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class QueryBodySyntax : SyntaxNode
{
    public QueryBodySyntax()
    {
        Clauses = null!;
        SelectOrGroup = null!;
        Continuation = null!;
        Parent = null;
    }

    public QueryBodySyntax(Microsoft.CodeAnalysis.CSharp.Syntax.QueryBodySyntax node, SyntaxNode? parent)
    {
        Clauses = Cloner.ListFrom<QueryClauseSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.QueryClauseSyntax>(node.Clauses, this);
        SelectOrGroup = SelectOrGroupClauseSyntax.From(node.SelectOrGroup, this);
        Continuation = node.Continuation is null ? null : new QueryContinuationSyntax(node.Continuation, this);
        Parent = parent;
    }

    public SyntaxList<QueryClauseSyntax> Clauses { get; init; }
    public SelectOrGroupClauseSyntax SelectOrGroup { get; init; }
    public QueryContinuationSyntax? Continuation { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Clauses.AppendTo(stringBuilder);
        SelectOrGroup.AppendTo(stringBuilder);
        Continuation?.AppendTo(stringBuilder);
    }
}
