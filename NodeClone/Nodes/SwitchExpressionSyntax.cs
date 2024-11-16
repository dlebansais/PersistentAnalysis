namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class SwitchExpressionSyntax : ExpressionSyntax
{
    public SwitchExpressionSyntax()
    {
        GoverningExpression = null!;
        SwitchKeyword = null!;
        OpenBraceToken = null!;
        Arms = null!;
        CloseBraceToken = null!;
        Parent = null;
    }

    public SwitchExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.SwitchExpressionSyntax node, SyntaxNode? parent)
    {
        GoverningExpression = ExpressionSyntax.From(node.GoverningExpression, this);
        SwitchKeyword = Cloner.ToToken(node.SwitchKeyword);
        OpenBraceToken = Cloner.ToToken(node.OpenBraceToken);
        Arms = Cloner.SeparatedListFrom<SwitchExpressionArmSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.SwitchExpressionArmSyntax>(node.Arms, this);
        CloseBraceToken = Cloner.ToToken(node.CloseBraceToken);
        Parent = parent;
    }

    public ExpressionSyntax GoverningExpression { get; init; }
    public SyntaxToken SwitchKeyword { get; init; }
    public SyntaxToken OpenBraceToken { get; init; }
    public SeparatedSyntaxList<SwitchExpressionArmSyntax> Arms { get; init; }
    public SyntaxToken CloseBraceToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        GoverningExpression.AppendTo(stringBuilder);
        SwitchKeyword.AppendTo(stringBuilder);
        OpenBraceToken.AppendTo(stringBuilder);
        Arms.AppendTo(stringBuilder);
        CloseBraceToken.AppendTo(stringBuilder);
    }
}
