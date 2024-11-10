namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class BreakStatementSyntax : StatementSyntax
{
    public BreakStatementSyntax()
    {
        AttributeLists = null!;
        BreakKeyword = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public BreakStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.BreakStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        BreakKeyword = Cloner.ToToken(node.BreakKeyword);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken BreakKeyword { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
