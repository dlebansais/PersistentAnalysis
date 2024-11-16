namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ForStatementSyntax : StatementSyntax
{
    public ForStatementSyntax()
    {
        AttributeLists = null!;
        ForKeyword = null!;
        OpenParenToken = null!;
        Declaration = null!;
        Initializers = null!;
        FirstSemicolonToken = null!;
        Condition = null!;
        SecondSemicolonToken = null!;
        Incrementors = null!;
        CloseParenToken = null!;
        Statement = null!;
        Parent = null;
    }

    public ForStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ForStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        ForKeyword = Cloner.ToToken(node.ForKeyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Declaration = node.Declaration is null ? null : new VariableDeclarationSyntax(node.Declaration, this);
        Initializers = Cloner.SeparatedListFrom<ExpressionSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax>(node.Initializers, this);
        FirstSemicolonToken = Cloner.ToToken(node.FirstSemicolonToken);
        Condition = node.Condition is null ? null : ExpressionSyntax.From(node.Condition, this);
        SecondSemicolonToken = Cloner.ToToken(node.SecondSemicolonToken);
        Incrementors = Cloner.SeparatedListFrom<ExpressionSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax>(node.Incrementors, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Statement = StatementSyntax.From(node.Statement, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken ForKeyword { get; init; }
    public SyntaxToken OpenParenToken { get; init; }
    public VariableDeclarationSyntax? Declaration { get; init; }
    public SeparatedSyntaxList<ExpressionSyntax> Initializers { get; init; }
    public SyntaxToken FirstSemicolonToken { get; init; }
    public ExpressionSyntax? Condition { get; init; }
    public SyntaxToken SecondSemicolonToken { get; init; }
    public SeparatedSyntaxList<ExpressionSyntax> Incrementors { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public StatementSyntax Statement { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        AttributeLists.AppendTo(stringBuilder);
        ForKeyword.AppendTo(stringBuilder);
        OpenParenToken.AppendTo(stringBuilder);
        Declaration?.AppendTo(stringBuilder);
        Initializers.AppendTo(stringBuilder);
        FirstSemicolonToken.AppendTo(stringBuilder);
        Condition?.AppendTo(stringBuilder);
        SecondSemicolonToken.AppendTo(stringBuilder);
        Incrementors.AppendTo(stringBuilder);
        CloseParenToken.AppendTo(stringBuilder);
        Statement.AppendTo(stringBuilder);
    }
}
