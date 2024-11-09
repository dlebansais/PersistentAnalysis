namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class InterpolatedStringTextSyntax : InterpolatedStringContentSyntax
{
    public InterpolatedStringTextSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringTextSyntax node, SyntaxNode? parent)
    {
        TextToken = Cloner.ToToken(node.TextToken);
        Parent = parent;
    }

    public SyntaxToken TextToken { get; }
    public SyntaxNode? Parent { get; }
}
