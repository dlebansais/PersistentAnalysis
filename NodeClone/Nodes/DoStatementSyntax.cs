namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class DoStatementSyntax : StatementSyntax
{
    public DoStatementSyntax()
    {
        AttributeLists = null!;
        DoKeyword = null!;
        Statement = null!;
        WhileKeyword = null!;
        OpenParenToken = null!;
        Condition = null!;
        CloseParenToken = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public DoStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.DoStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        DoKeyword = Cloner.ToToken(node.DoKeyword);
        Statement = StatementSyntax.From(node.Statement, this);
        WhileKeyword = Cloner.ToToken(node.WhileKeyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Condition = ExpressionSyntax.From(node.Condition, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken DoKeyword { get; init; }
    public StatementSyntax Statement { get; init; }
    public SyntaxToken WhileKeyword { get; init; }
    public SyntaxToken OpenParenToken { get; init; }
    public ExpressionSyntax Condition { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
