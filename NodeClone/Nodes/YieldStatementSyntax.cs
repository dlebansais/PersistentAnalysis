namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class YieldStatementSyntax : StatementSyntax
{
    public YieldStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.YieldStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        YieldKeyword = Cloner.ToToken(node.YieldKeyword);
        ReturnOrBreakKeyword = Cloner.ToToken(node.ReturnOrBreakKeyword);
        Expression = node.Expression is null ? null : ExpressionSyntax.From(node.Expression, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; }
    public SyntaxToken YieldKeyword { get; }
    public SyntaxToken ReturnOrBreakKeyword { get; }
    public ExpressionSyntax? Expression { get; }
    public SyntaxToken SemicolonToken { get; }
    public SyntaxNode? Parent { get; }
}
