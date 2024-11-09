namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class DoStatementSyntax : StatementSyntax
{
    public DoStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.DoStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        DoKeyword = Cloner.ToToken(node.DoKeyword);
        Statement = StatementSyntax.From(node.Statement, this);
        WhileKeyword = Cloner.ToToken(node.WhileKeyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Condition = ExpressionSyntax.From(node.Condition, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; }
    public SyntaxToken DoKeyword { get; }
    public StatementSyntax Statement { get; }
    public SyntaxToken WhileKeyword { get; }
    public SyntaxToken OpenParenToken { get; }
    public ExpressionSyntax Condition { get; }
    public SyntaxToken CloseParenToken { get; }
    public SyntaxToken SemicolonToken { get; }
    public SyntaxNode? Parent { get; }
}
