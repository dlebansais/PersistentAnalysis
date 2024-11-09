namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class WithExpressionSyntax : ExpressionSyntax
{
    public WithExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.WithExpressionSyntax node, SyntaxNode? parent)
    {
        Expression = ExpressionSyntax.From(node.Expression, this);
        WithKeyword = Cloner.ToToken(node.WithKeyword);
        Initializer = new InitializerExpressionSyntax(node.Initializer, this);
        Parent = parent;
    }

    public ExpressionSyntax Expression { get; }
    public SyntaxToken WithKeyword { get; }
    public InitializerExpressionSyntax Initializer { get; }
    public SyntaxNode? Parent { get; }
}
