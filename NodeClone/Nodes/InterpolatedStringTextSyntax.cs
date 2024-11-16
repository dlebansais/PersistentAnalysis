namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class InterpolatedStringTextSyntax : InterpolatedStringContentSyntax
{
    public InterpolatedStringTextSyntax()
    {
        TextToken = null!;
        Parent = null;
    }

    public InterpolatedStringTextSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringTextSyntax node, SyntaxNode? parent)
    {
        TextToken = Cloner.ToToken(node.TextToken);
        Parent = parent;
    }

    public SyntaxToken TextToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        TextToken.AppendTo(stringBuilder);
    }
}
