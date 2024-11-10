namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ConditionalExpressionSyntax : ExpressionSyntax
{
    public ConditionalExpressionSyntax()
    {
        Condition = null!;
        QuestionToken = null!;
        WhenTrue = null!;
        ColonToken = null!;
        WhenFalse = null!;
        Parent = null;
    }

    public ConditionalExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ConditionalExpressionSyntax node, SyntaxNode? parent)
    {
        Condition = ExpressionSyntax.From(node.Condition, this);
        QuestionToken = Cloner.ToToken(node.QuestionToken);
        WhenTrue = ExpressionSyntax.From(node.WhenTrue, this);
        ColonToken = Cloner.ToToken(node.ColonToken);
        WhenFalse = ExpressionSyntax.From(node.WhenFalse, this);
        Parent = parent;
    }

    public ExpressionSyntax Condition { get; init; }
    public SyntaxToken QuestionToken { get; init; }
    public ExpressionSyntax WhenTrue { get; init; }
    public SyntaxToken ColonToken { get; init; }
    public ExpressionSyntax WhenFalse { get; init; }
    public SyntaxNode? Parent { get; init; }
}
