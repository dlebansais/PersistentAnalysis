namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ForEachVariableStatementSyntax : CommonForEachStatementSyntax
{
    public ForEachVariableStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        AwaitKeyword = Cloner.ToToken(node.AwaitKeyword);
        ForEachKeyword = Cloner.ToToken(node.ForEachKeyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Variable = ExpressionSyntax.From(node.Variable, this);
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
    public ExpressionSyntax Variable { get; }
    public SyntaxToken InKeyword { get; }
    public ExpressionSyntax Expression { get; }
    public SyntaxToken CloseParenToken { get; }
    public StatementSyntax Statement { get; }
    public SyntaxNode? Parent { get; }
}
