namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ExpressionStatementSyntax : StatementSyntax
{
    public ExpressionStatementSyntax()
    {
        AttributeLists = null!;
        Expression = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public ExpressionStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        Expression = ExpressionSyntax.From(node.Expression, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
