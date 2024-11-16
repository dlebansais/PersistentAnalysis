namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class MemberAccessExpressionSyntax : ExpressionSyntax
{
    public MemberAccessExpressionSyntax()
    {
        Expression = null!;
        OperatorToken = null!;
        Name = null!;
        Parent = null;
    }

    public MemberAccessExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.MemberAccessExpressionSyntax node, SyntaxNode? parent)
    {
        Expression = ExpressionSyntax.From(node.Expression, this);
        OperatorToken = Cloner.ToToken(node.OperatorToken);
        Name = SimpleNameSyntax.From(node.Name, this);
        Parent = parent;
    }

    public ExpressionSyntax Expression { get; init; }
    public SyntaxToken OperatorToken { get; init; }
    public SimpleNameSyntax Name { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Expression.AppendTo(stringBuilder);
        OperatorToken.AppendTo(stringBuilder);
        Name.AppendTo(stringBuilder);
    }
}
