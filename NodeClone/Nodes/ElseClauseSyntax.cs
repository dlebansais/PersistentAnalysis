namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ElseClauseSyntax : SyntaxNode
{
    public ElseClauseSyntax()
    {
        ElseKeyword = null!;
        Statement = null!;
        Parent = null;
    }

    public ElseClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ElseClauseSyntax node, SyntaxNode? parent)
    {
        ElseKeyword = Cloner.ToToken(node.ElseKeyword);
        Statement = StatementSyntax.From(node.Statement, this);
        Parent = parent;
    }

    public SyntaxToken ElseKeyword { get; init; }
    public StatementSyntax Statement { get; init; }
    public SyntaxNode? Parent { get; init; }
}
