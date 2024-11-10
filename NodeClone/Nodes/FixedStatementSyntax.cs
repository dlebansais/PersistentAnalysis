namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class FixedStatementSyntax : StatementSyntax
{
    public FixedStatementSyntax()
    {
        AttributeLists = null!;
        FixedKeyword = null!;
        OpenParenToken = null!;
        Declaration = null!;
        CloseParenToken = null!;
        Statement = null!;
        Parent = null;
    }

    public FixedStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.FixedStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        FixedKeyword = Cloner.ToToken(node.FixedKeyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Declaration = new VariableDeclarationSyntax(node.Declaration, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Statement = StatementSyntax.From(node.Statement, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken FixedKeyword { get; init; }
    public SyntaxToken OpenParenToken { get; init; }
    public VariableDeclarationSyntax Declaration { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public StatementSyntax Statement { get; init; }
    public SyntaxNode? Parent { get; init; }
}
