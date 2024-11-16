namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class SlicePatternSyntax : PatternSyntax
{
    public SlicePatternSyntax()
    {
        DotDotToken = null!;
        Pattern = null!;
        Parent = null;
    }

    public SlicePatternSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.SlicePatternSyntax node, SyntaxNode? parent)
    {
        DotDotToken = Cloner.ToToken(node.DotDotToken);
        Pattern = node.Pattern is null ? null : PatternSyntax.From(node.Pattern, this);
        Parent = parent;
    }

    public SyntaxToken DotDotToken { get; init; }
    public PatternSyntax? Pattern { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        DotDotToken.AppendTo(stringBuilder);
        Pattern?.AppendTo(stringBuilder);
    }
}
