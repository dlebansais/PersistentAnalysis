namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class WhenClauseSyntax : SyntaxNode
{
    public WhenClauseSyntax()
    {
        WhenKeyword = null!;
        Condition = null!;
        Parent = null;
    }

    public WhenClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.WhenClauseSyntax node, SyntaxNode? parent)
    {
        WhenKeyword = Cloner.ToToken(node.WhenKeyword);
        Condition = ExpressionSyntax.From(node.Condition, this);
        Parent = parent;
    }

    public SyntaxToken WhenKeyword { get; init; }
    public ExpressionSyntax Condition { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        WhenKeyword.AppendTo(stringBuilder);
        Condition.AppendTo(stringBuilder);
    }
}
