namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ThisExpressionSyntax : InstanceExpressionSyntax
{
    public ThisExpressionSyntax()
    {
        Token = null!;
        Parent = null;
    }

    public ThisExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ThisExpressionSyntax node, SyntaxNode? parent)
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
