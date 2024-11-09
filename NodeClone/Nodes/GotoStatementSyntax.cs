namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class GotoStatementSyntax : StatementSyntax
{
    public GotoStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.GotoStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        GotoKeyword = Cloner.ToToken(node.GotoKeyword);
        CaseOrDefaultKeyword = Cloner.ToToken(node.CaseOrDefaultKeyword);
        Expression = node.Expression is null ? null : ExpressionSyntax.From(node.Expression, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; }
    public SyntaxToken GotoKeyword { get; }
    public SyntaxToken CaseOrDefaultKeyword { get; }
    public ExpressionSyntax? Expression { get; }
    public SyntaxToken SemicolonToken { get; }
    public SyntaxNode? Parent { get; }
}
