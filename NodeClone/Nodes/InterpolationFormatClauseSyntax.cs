namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class InterpolationFormatClauseSyntax : SyntaxNode
{
    public InterpolationFormatClauseSyntax()
    {
        ColonToken = null!;
        FormatStringToken = null!;
        Parent = null;
    }

    public InterpolationFormatClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolationFormatClauseSyntax node, SyntaxNode? parent)
    {
        ColonToken = Cloner.ToToken(node.ColonToken);
        FormatStringToken = Cloner.ToToken(node.FormatStringToken);
        Parent = parent;
    }

    public SyntaxToken ColonToken { get; init; }
    public SyntaxToken FormatStringToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        ColonToken.AppendTo(stringBuilder);
        FormatStringToken.AppendTo(stringBuilder);
    }
}
