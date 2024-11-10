namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ThrowStatementSyntax : StatementSyntax
{
    public ThrowStatementSyntax()
    {
        AttributeLists = null!;
        ThrowKeyword = null!;
        Expression = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public ThrowStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ThrowStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        ThrowKeyword = Cloner.ToToken(node.ThrowKeyword);
        Expression = node.Expression is null ? null : ExpressionSyntax.From(node.Expression, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken ThrowKeyword { get; init; }
    public ExpressionSyntax? Expression { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
