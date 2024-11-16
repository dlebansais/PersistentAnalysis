namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class SwitchStatementSyntax : StatementSyntax
{
    public SwitchStatementSyntax()
    {
        AttributeLists = null!;
        SwitchKeyword = null!;
        OpenParenToken = null!;
        Expression = null!;
        CloseParenToken = null!;
        OpenBraceToken = null!;
        Sections = null!;
        CloseBraceToken = null!;
        Parent = null;
    }

    public SwitchStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.SwitchStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        SwitchKeyword = Cloner.ToToken(node.SwitchKeyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Expression = ExpressionSyntax.From(node.Expression, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        OpenBraceToken = Cloner.ToToken(node.OpenBraceToken);
        Sections = Cloner.ListFrom<SwitchSectionSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.SwitchSectionSyntax>(node.Sections, this);
        CloseBraceToken = Cloner.ToToken(node.CloseBraceToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken SwitchKeyword { get; init; }
    public SyntaxToken OpenParenToken { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public SyntaxToken OpenBraceToken { get; init; }
    public SyntaxList<SwitchSectionSyntax> Sections { get; init; }
    public SyntaxToken CloseBraceToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        AttributeLists.AppendTo(stringBuilder);
        SwitchKeyword.AppendTo(stringBuilder);
        OpenParenToken.AppendTo(stringBuilder);
        Expression.AppendTo(stringBuilder);
        CloseParenToken.AppendTo(stringBuilder);
        OpenBraceToken.AppendTo(stringBuilder);
        Sections.AppendTo(stringBuilder);
        CloseBraceToken.AppendTo(stringBuilder);
    }
}
