namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class YieldStatementSyntax : StatementSyntax
{
    public YieldStatementSyntax()
    {
        AttributeLists = null!;
        YieldKeyword = null!;
        ReturnOrBreakKeyword = null!;
        Expression = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public YieldStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.YieldStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        YieldKeyword = Cloner.ToToken(node.YieldKeyword);
        ReturnOrBreakKeyword = Cloner.ToToken(node.ReturnOrBreakKeyword);
        Expression = node.Expression is null ? null : ExpressionSyntax.From(node.Expression, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken YieldKeyword { get; init; }
    public SyntaxToken ReturnOrBreakKeyword { get; init; }
    public ExpressionSyntax? Expression { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        AttributeLists.AppendTo(stringBuilder);
        YieldKeyword.AppendTo(stringBuilder);
        ReturnOrBreakKeyword.AppendTo(stringBuilder);
        Expression?.AppendTo(stringBuilder);
        SemicolonToken.AppendTo(stringBuilder);
    }
}
