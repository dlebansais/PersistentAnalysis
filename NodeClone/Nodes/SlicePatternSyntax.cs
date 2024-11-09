namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class SlicePatternSyntax : PatternSyntax
{
    public SlicePatternSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.SlicePatternSyntax node, SyntaxNode? parent)
    {
        DotDotToken = Cloner.ToToken(node.DotDotToken);
        Pattern = node.Pattern is null ? null : PatternSyntax.From(node.Pattern, this);
        Parent = parent;
    }

    public SyntaxToken DotDotToken { get; }
    public PatternSyntax? Pattern { get; }
    public SyntaxNode? Parent { get; }
}
