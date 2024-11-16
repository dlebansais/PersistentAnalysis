namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ForEachVariableStatementSyntax : CommonForEachStatementSyntax
{
    public ForEachVariableStatementSyntax()
    {
        AttributeLists = null!;
        AwaitKeyword = null!;
        ForEachKeyword = null!;
        OpenParenToken = null!;
        Variable = null!;
        InKeyword = null!;
        Expression = null!;
        CloseParenToken = null!;
        Statement = null!;
        Parent = null;
    }

    public ForEachVariableStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
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

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken AwaitKeyword { get; init; }
    public SyntaxToken ForEachKeyword { get; init; }
    public SyntaxToken OpenParenToken { get; init; }
    public ExpressionSyntax Variable { get; init; }
    public SyntaxToken InKeyword { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public StatementSyntax Statement { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        AttributeLists.AppendTo(stringBuilder);
        AwaitKeyword.AppendTo(stringBuilder);
        ForEachKeyword.AppendTo(stringBuilder);
        OpenParenToken.AppendTo(stringBuilder);
        Variable.AppendTo(stringBuilder);
        InKeyword.AppendTo(stringBuilder);
        Expression.AppendTo(stringBuilder);
        CloseParenToken.AppendTo(stringBuilder);
        Statement.AppendTo(stringBuilder);
    }
}
