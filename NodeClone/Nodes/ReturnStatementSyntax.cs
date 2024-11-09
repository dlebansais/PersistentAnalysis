namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ReturnStatementSyntax : StatementSyntax
{
    public ReturnStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ReturnStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        ReturnKeyword = Cloner.ToToken(node.ReturnKeyword);
        Expression = node.Expression is null ? null : ExpressionSyntax.From(node.Expression, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; }
    public SyntaxToken ReturnKeyword { get; }
    public ExpressionSyntax? Expression { get; }
    public SyntaxToken SemicolonToken { get; }
    public SyntaxNode? Parent { get; }
}
