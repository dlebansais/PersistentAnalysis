namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class LiteralExpressionSyntax : ExpressionSyntax
{
    public LiteralExpressionSyntax()
    {
        Token = null!;
        Parent = null;
    }

    public LiteralExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.LiteralExpressionSyntax node, SyntaxNode? parent)
    {
        Token = Cloner.ToToken(node.Token);
        Parent = parent;
    }

    public SyntaxToken Token { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Token.AppendTo(stringBuilder);
    }
}
