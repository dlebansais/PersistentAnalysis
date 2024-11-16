namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class NameColonSyntax : BaseExpressionColonSyntax
{
    public NameColonSyntax()
    {
        Expression = null!;
        Name = null!;
        ColonToken = null!;
        Parent = null;
    }

    public NameColonSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.NameColonSyntax node, SyntaxNode? parent)
    {
        Expression = ExpressionSyntax.From(node.Expression, this);
        Name = new IdentifierNameSyntax(node.Name, this);
        ColonToken = Cloner.ToToken(node.ColonToken);
        Parent = parent;
    }

    public ExpressionSyntax Expression { get; init; }
    public IdentifierNameSyntax Name { get; init; }
    public SyntaxToken ColonToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Expression.AppendTo(stringBuilder);
        Name.AppendTo(stringBuilder);
        ColonToken.AppendTo(stringBuilder);
    }
}
