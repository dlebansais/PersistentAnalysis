namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class BaseExpressionSyntax : InstanceExpressionSyntax
{
    public BaseExpressionSyntax()
    {
        Token = null!;
        Parent = null;
    }

    public BaseExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.BaseExpressionSyntax node, SyntaxNode? parent)
    {
        Token = Cloner.ToToken(node.Token);
        Parent = parent;
    }

    public SyntaxToken Token { get; init; }
    public SyntaxNode? Parent { get; init; }
}
