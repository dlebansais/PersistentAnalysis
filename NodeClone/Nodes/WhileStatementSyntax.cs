namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class WhileStatementSyntax : StatementSyntax
{
    public WhileStatementSyntax()
    {
        AttributeLists = null!;
        WhileKeyword = null!;
        OpenParenToken = null!;
        Condition = null!;
        CloseParenToken = null!;
        Statement = null!;
        Parent = null;
    }

    public WhileStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.WhileStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        WhileKeyword = Cloner.ToToken(node.WhileKeyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Condition = ExpressionSyntax.From(node.Condition, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Statement = StatementSyntax.From(node.Statement, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken WhileKeyword { get; init; }
    public SyntaxToken OpenParenToken { get; init; }
    public ExpressionSyntax Condition { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public StatementSyntax Statement { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        AttributeLists.AppendTo(stringBuilder);
        WhileKeyword.AppendTo(stringBuilder);
        OpenParenToken.AppendTo(stringBuilder);
        Condition.AppendTo(stringBuilder);
        CloseParenToken.AppendTo(stringBuilder);
        Statement.AppendTo(stringBuilder);
    }
}
