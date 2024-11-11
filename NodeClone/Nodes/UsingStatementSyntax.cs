namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class UsingStatementSyntax : StatementSyntax
{
    public UsingStatementSyntax()
    {
        AttributeLists = null!;
        AwaitKeyword = null!;
        UsingKeyword = null!;
        OpenParenToken = null!;
        Declaration = null!;
        Expression = null!;
        CloseParenToken = null!;
        Statement = null!;
        Parent = null;
    }

    public UsingStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        AwaitKeyword = Cloner.ToToken(node.AwaitKeyword);
        UsingKeyword = Cloner.ToToken(node.UsingKeyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Declaration = node.Declaration is null ? null : new VariableDeclarationSyntax(node.Declaration, this);
        Expression = node.Expression is null ? null : ExpressionSyntax.From(node.Expression, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Statement = StatementSyntax.From(node.Statement, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken AwaitKeyword { get; init; }
    public SyntaxToken UsingKeyword { get; init; }
    public SyntaxToken OpenParenToken { get; init; }
    public VariableDeclarationSyntax? Declaration { get; init; }
    public ExpressionSyntax? Expression { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public StatementSyntax Statement { get; init; }
    public SyntaxNode? Parent { get; init; }
}
