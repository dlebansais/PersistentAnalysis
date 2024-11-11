namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ForEachStatementSyntax : CommonForEachStatementSyntax
{
    public ForEachStatementSyntax()
    {
        AttributeLists = null!;
        AwaitKeyword = null!;
        ForEachKeyword = null!;
        OpenParenToken = null!;
        Type = null!;
        Identifier = null!;
        InKeyword = null!;
        Expression = null!;
        CloseParenToken = null!;
        Statement = null!;
        Parent = null;
    }

    public ForEachStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ForEachStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        AwaitKeyword = Cloner.ToToken(node.AwaitKeyword);
        ForEachKeyword = Cloner.ToToken(node.ForEachKeyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Type = TypeSyntax.From(node.Type, this);
        Identifier = Cloner.ToToken(node.Identifier);
        InKeyword = Cloner.ToToken(node.InKeyword);
        Expression = ExpressionSyntax.From(node.Expression, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Statement = StatementSyntax.From(node.Statement, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken AwaitKeyword { get; init; }
    public SyntaxToken ForEachKeyword { get; init; }
    public SyntaxToken OpenParenToken { get; init; }
    public TypeSyntax Type { get; init; }
    public SyntaxToken Identifier { get; init; }
    public SyntaxToken InKeyword { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public StatementSyntax Statement { get; init; }
    public SyntaxNode? Parent { get; init; }
}
