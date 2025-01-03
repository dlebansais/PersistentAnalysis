﻿namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class RefTypeExpressionSyntax : ExpressionSyntax
{
    public RefTypeExpressionSyntax()
    {
        Keyword = null!;
        OpenParenToken = null!;
        Expression = null!;
        CloseParenToken = null!;
        Parent = null;
    }

    public RefTypeExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.RefTypeExpressionSyntax node, SyntaxNode? parent)
    {
        Keyword = Cloner.ToToken(node.Keyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Expression = ExpressionSyntax.From(node.Expression, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken Keyword { get; init; }
    public SyntaxToken OpenParenToken { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Keyword.AppendTo(stringBuilder);
        OpenParenToken.AppendTo(stringBuilder);
        Expression.AppendTo(stringBuilder);
        CloseParenToken.AppendTo(stringBuilder);
    }
}
