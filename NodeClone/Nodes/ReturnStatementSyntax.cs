namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ReturnStatementSyntax : StatementSyntax
{
    public ReturnStatementSyntax()
    {
        AttributeLists = null!;
        ReturnKeyword = null!;
        Expression = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public ReturnStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ReturnStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        ReturnKeyword = Cloner.ToToken(node.ReturnKeyword);
        Expression = node.Expression is null ? null : ExpressionSyntax.From(node.Expression, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken ReturnKeyword { get; init; }
    public ExpressionSyntax? Expression { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
