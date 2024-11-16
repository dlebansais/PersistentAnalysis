namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class WithExpressionSyntax : ExpressionSyntax
{
    public WithExpressionSyntax()
    {
        Expression = null!;
        WithKeyword = null!;
        Initializer = null!;
        Parent = null;
    }

    public WithExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.WithExpressionSyntax node, SyntaxNode? parent)
    {
        Expression = ExpressionSyntax.From(node.Expression, this);
        WithKeyword = Cloner.ToToken(node.WithKeyword);
        Initializer = new InitializerExpressionSyntax(node.Initializer, this);
        Parent = parent;
    }

    public ExpressionSyntax Expression { get; init; }
    public SyntaxToken WithKeyword { get; init; }
    public InitializerExpressionSyntax Initializer { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Expression.AppendTo(stringBuilder);
        WithKeyword.AppendTo(stringBuilder);
        Initializer.AppendTo(stringBuilder);
    }
}
