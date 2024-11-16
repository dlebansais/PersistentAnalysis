namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class EqualsValueClauseSyntax : SyntaxNode
{
    public EqualsValueClauseSyntax()
    {
        EqualsToken = null!;
        Value = null!;
        Parent = null;
    }

    public EqualsValueClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.EqualsValueClauseSyntax node, SyntaxNode? parent)
    {
        EqualsToken = Cloner.ToToken(node.EqualsToken);
        Value = ExpressionSyntax.From(node.Value, this);
        Parent = parent;
    }

    public SyntaxToken EqualsToken { get; init; }
    public ExpressionSyntax Value { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        EqualsToken.AppendTo(stringBuilder);
        Value.AppendTo(stringBuilder);
    }
}
