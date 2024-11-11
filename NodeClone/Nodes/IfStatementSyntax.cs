namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class IfStatementSyntax : StatementSyntax
{
    public IfStatementSyntax()
    {
        AttributeLists = null!;
        IfKeyword = null!;
        OpenParenToken = null!;
        Condition = null!;
        CloseParenToken = null!;
        Statement = null!;
        Else = null!;
        Parent = null;
    }

    public IfStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.IfStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        IfKeyword = Cloner.ToToken(node.IfKeyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Condition = ExpressionSyntax.From(node.Condition, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Statement = StatementSyntax.From(node.Statement, this);
        Else = node.Else is null ? null : new ElseClauseSyntax(node.Else, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken IfKeyword { get; init; }
    public SyntaxToken OpenParenToken { get; init; }
    public ExpressionSyntax Condition { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public StatementSyntax Statement { get; init; }
    public ElseClauseSyntax? Else { get; init; }
    public SyntaxNode? Parent { get; init; }
}
