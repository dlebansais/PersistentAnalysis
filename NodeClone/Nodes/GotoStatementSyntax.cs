namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class GotoStatementSyntax : StatementSyntax
{
    public GotoStatementSyntax()
    {
        AttributeLists = null!;
        GotoKeyword = null!;
        CaseOrDefaultKeyword = null!;
        Expression = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public GotoStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.GotoStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        GotoKeyword = Cloner.ToToken(node.GotoKeyword);
        CaseOrDefaultKeyword = Cloner.ToToken(node.CaseOrDefaultKeyword);
        Expression = node.Expression is null ? null : ExpressionSyntax.From(node.Expression, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken GotoKeyword { get; init; }
    public SyntaxToken CaseOrDefaultKeyword { get; init; }
    public ExpressionSyntax? Expression { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
