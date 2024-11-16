namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class InterpolationSyntax : InterpolatedStringContentSyntax
{
    public InterpolationSyntax()
    {
        OpenBraceToken = null!;
        Expression = null!;
        AlignmentClause = null!;
        FormatClause = null!;
        CloseBraceToken = null!;
        Parent = null;
    }

    public InterpolationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolationSyntax node, SyntaxNode? parent)
    {
        OpenBraceToken = Cloner.ToToken(node.OpenBraceToken);
        Expression = ExpressionSyntax.From(node.Expression, this);
        AlignmentClause = node.AlignmentClause is null ? null : new InterpolationAlignmentClauseSyntax(node.AlignmentClause, this);
        FormatClause = node.FormatClause is null ? null : new InterpolationFormatClauseSyntax(node.FormatClause, this);
        CloseBraceToken = Cloner.ToToken(node.CloseBraceToken);
        Parent = parent;
    }

    public SyntaxToken OpenBraceToken { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public InterpolationAlignmentClauseSyntax? AlignmentClause { get; init; }
    public InterpolationFormatClauseSyntax? FormatClause { get; init; }
    public SyntaxToken CloseBraceToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        OpenBraceToken.AppendTo(stringBuilder);
        Expression.AppendTo(stringBuilder);
        AlignmentClause?.AppendTo(stringBuilder);
        FormatClause?.AppendTo(stringBuilder);
        CloseBraceToken.AppendTo(stringBuilder);
    }
}
