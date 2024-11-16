namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class AttributeArgumentSyntax : SyntaxNode
{
    public AttributeArgumentSyntax()
    {
        NameEquals = null!;
        NameColon = null!;
        Expression = null!;
        Parent = null;
    }

    public AttributeArgumentSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.AttributeArgumentSyntax node, SyntaxNode? parent)
    {
        NameEquals = node.NameEquals is null ? null : new NameEqualsSyntax(node.NameEquals, this);
        NameColon = node.NameColon is null ? null : new NameColonSyntax(node.NameColon, this);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public NameEqualsSyntax? NameEquals { get; init; }
    public NameColonSyntax? NameColon { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        NameEquals?.AppendTo(stringBuilder);
        NameColon?.AppendTo(stringBuilder);
        Expression.AppendTo(stringBuilder);
    }
}
