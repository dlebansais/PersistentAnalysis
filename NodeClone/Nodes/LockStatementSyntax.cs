namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class LockStatementSyntax : StatementSyntax
{
    public LockStatementSyntax()
    {
        AttributeLists = null!;
        LockKeyword = null!;
        OpenParenToken = null!;
        Expression = null!;
        CloseParenToken = null!;
        Statement = null!;
        Parent = null;
    }

    public LockStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        LockKeyword = Cloner.ToToken(node.LockKeyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Expression = ExpressionSyntax.From(node.Expression, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Statement = StatementSyntax.From(node.Statement, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken LockKeyword { get; init; }
    public SyntaxToken OpenParenToken { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public StatementSyntax Statement { get; init; }
    public SyntaxNode? Parent { get; init; }
}
