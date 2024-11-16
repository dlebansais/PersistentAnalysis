namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class QueryContinuationSyntax : SyntaxNode
{
    public QueryContinuationSyntax()
    {
        IntoKeyword = null!;
        Identifier = null!;
        Body = null!;
        Parent = null;
    }

    public QueryContinuationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.QueryContinuationSyntax node, SyntaxNode? parent)
    {
        IntoKeyword = Cloner.ToToken(node.IntoKeyword);
        Identifier = Cloner.ToToken(node.Identifier);
        Body = new QueryBodySyntax(node.Body, this);
        Parent = parent;
    }

    public SyntaxToken IntoKeyword { get; init; }
    public SyntaxToken Identifier { get; init; }
    public QueryBodySyntax Body { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        IntoKeyword.AppendTo(stringBuilder);
        Identifier.AppendTo(stringBuilder);
        Body.AppendTo(stringBuilder);
    }
}
