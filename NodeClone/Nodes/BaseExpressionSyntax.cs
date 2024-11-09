namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class BaseExpressionSyntax : InstanceExpressionSyntax
{
    public BaseExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.BaseExpressionSyntax node, SyntaxNode? parent)
    {
        Token = Cloner.ToToken(node.Token);
        Parent = parent;
    }

    public SyntaxToken Token { get; }
    public SyntaxNode? Parent { get; }
}
