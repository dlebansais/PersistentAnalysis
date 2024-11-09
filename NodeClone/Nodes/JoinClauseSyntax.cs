namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class JoinClauseSyntax : QueryClauseSyntax
{
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

    public SyntaxToken JoinKeyword { get; }
    public TypeSyntax? Type { get; }
    public SyntaxToken Identifier { get; }
    public SyntaxToken InKeyword { get; }
    public ExpressionSyntax InExpression { get; }
    public SyntaxToken OnKeyword { get; }
    public ExpressionSyntax LeftExpression { get; }
    public SyntaxToken EqualsKeyword { get; }
    public ExpressionSyntax RightExpression { get; }
    public JoinIntoClauseSyntax? Into { get; }
    public SyntaxNode? Parent { get; }
}
