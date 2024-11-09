namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class SwitchStatementSyntax : StatementSyntax
{
    public SwitchStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.SwitchStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        SwitchKeyword = Cloner.ToToken(node.SwitchKeyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Expression = ExpressionSyntax.From(node.Expression, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        OpenBraceToken = Cloner.ToToken(node.OpenBraceToken);
        Sections = Cloner.ListFrom<SwitchSectionSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.SwitchSectionSyntax>(node.Sections, parent);
        CloseBraceToken = Cloner.ToToken(node.CloseBraceToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; }
    public SyntaxToken SwitchKeyword { get; }
    public SyntaxToken OpenParenToken { get; }
    public ExpressionSyntax Expression { get; }
    public SyntaxToken CloseParenToken { get; }
    public SyntaxToken OpenBraceToken { get; }
    public SyntaxList<SwitchSectionSyntax> Sections { get; }
    public SyntaxToken CloseBraceToken { get; }
    public SyntaxNode? Parent { get; }
}
