namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ContinueStatementSyntax : StatementSyntax
{
    public ContinueStatementSyntax()
    {
        AttributeLists = null!;
        ContinueKeyword = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public ContinueStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ContinueStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        ContinueKeyword = Cloner.ToToken(node.ContinueKeyword);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken ContinueKeyword { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
