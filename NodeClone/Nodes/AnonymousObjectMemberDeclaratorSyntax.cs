namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class AnonymousObjectMemberDeclaratorSyntax : SyntaxNode
{
    public AnonymousObjectMemberDeclaratorSyntax()
    {
        NameEquals = null!;
        Expression = null!;
        Parent = null;
    }

    public AnonymousObjectMemberDeclaratorSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousObjectMemberDeclaratorSyntax node, SyntaxNode? parent)
    {
        NameEquals = node.NameEquals is null ? null : new NameEqualsSyntax(node.NameEquals, this);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public NameEqualsSyntax? NameEquals { get; init; }
    public ExpressionSyntax Expression { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        NameEquals?.AppendTo(stringBuilder);
        Expression.AppendTo(stringBuilder);
    }
}
