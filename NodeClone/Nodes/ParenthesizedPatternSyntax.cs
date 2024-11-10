namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ParenthesizedPatternSyntax : PatternSyntax
{
    public ParenthesizedPatternSyntax()
    {
        OpenParenToken = null!;
        Pattern = null!;
        CloseParenToken = null!;
        Parent = null;
    }

    public ParenthesizedPatternSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedPatternSyntax node, SyntaxNode? parent)
    {
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Pattern = PatternSyntax.From(node.Pattern, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken OpenParenToken { get; init; }
    public PatternSyntax Pattern { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
