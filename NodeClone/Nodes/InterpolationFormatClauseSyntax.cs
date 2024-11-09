namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class InterpolationFormatClauseSyntax : SyntaxNode
{
    public InterpolationFormatClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolationFormatClauseSyntax node, SyntaxNode? parent)
    {
        ColonToken = Cloner.ToToken(node.ColonToken);
        FormatStringToken = Cloner.ToToken(node.FormatStringToken);
        Parent = parent;
    }

    public SyntaxToken ColonToken { get; }
    public SyntaxToken FormatStringToken { get; }
    public SyntaxNode? Parent { get; }
}
