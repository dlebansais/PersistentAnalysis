namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class UsingStatementSyntax : StatementSyntax
{
    public UsingStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        AwaitKeyword = Cloner.ToToken(node.AwaitKeyword);
        UsingKeyword = Cloner.ToToken(node.UsingKeyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Declaration = node.Declaration is null ? null : new VariableDeclarationSyntax(node.Declaration, this);
        Expression = node.Expression is null ? null : ExpressionSyntax.From(node.Expression, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Statement = StatementSyntax.From(node.Statement, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; }
    public SyntaxToken AwaitKeyword { get; }
    public SyntaxToken UsingKeyword { get; }
    public SyntaxToken OpenParenToken { get; }
    public VariableDeclarationSyntax? Declaration { get; }
    public ExpressionSyntax? Expression { get; }
    public SyntaxToken CloseParenToken { get; }
    public StatementSyntax Statement { get; }
    public SyntaxNode? Parent { get; }
}
