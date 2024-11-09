namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ForEachStatementSyntax : CommonForEachStatementSyntax
{
    public ForEachStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ForEachStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
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

    public SyntaxList<AttributeListSyntax> AttributeLists { get; }
    public SyntaxToken AwaitKeyword { get; }
    public SyntaxToken ForEachKeyword { get; }
    public SyntaxToken OpenParenToken { get; }
    public TypeSyntax Type { get; }
    public SyntaxToken Identifier { get; }
    public SyntaxToken InKeyword { get; }
    public ExpressionSyntax Expression { get; }
    public SyntaxToken CloseParenToken { get; }
    public StatementSyntax Statement { get; }
    public SyntaxNode? Parent { get; }
}
