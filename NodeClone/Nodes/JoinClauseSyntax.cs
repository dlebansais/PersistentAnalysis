namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class JoinClauseSyntax : QueryClauseSyntax
{
    public JoinClauseSyntax()
    {
        JoinKeyword = null!;
        Type = null!;
        Identifier = null!;
        InKeyword = null!;
        InExpression = null!;
        OnKeyword = null!;
        LeftExpression = null!;
        EqualsKeyword = null!;
        RightExpression = null!;
        Into = null!;
        Parent = null;
    }

    public JoinClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.JoinClauseSyntax node, SyntaxNode? parent)
    {
        JoinKeyword = Cloner.ToToken(node.JoinKeyword);
        Type = node.Type is null ? null : TypeSyntax.From(node.Type, this);
        Identifier = Cloner.ToToken(node.Identifier);
        InKeyword = Cloner.ToToken(node.InKeyword);
        InExpression = ExpressionSyntax.From(node.InExpression, this);
        OnKeyword = Cloner.ToToken(node.OnKeyword);
        LeftExpression = ExpressionSyntax.From(node.LeftExpression, this);
        EqualsKeyword = Cloner.ToToken(node.EqualsKeyword);
        RightExpression = ExpressionSyntax.From(node.RightExpression, this);
        Into = node.Into is null ? null : new JoinIntoClauseSyntax(node.Into, this);
        Parent = parent;
    }

    public SyntaxToken JoinKeyword { get; init; }
    public TypeSyntax? Type { get; init; }
    public SyntaxToken Identifier { get; init; }
    public SyntaxToken InKeyword { get; init; }
    public ExpressionSyntax InExpression { get; init; }
    public SyntaxToken OnKeyword { get; init; }
    public ExpressionSyntax LeftExpression { get; init; }
    public SyntaxToken EqualsKeyword { get; init; }
    public ExpressionSyntax RightExpression { get; init; }
    public JoinIntoClauseSyntax? Into { get; init; }
    public SyntaxNode? Parent { get; init; }
}
