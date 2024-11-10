namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class UnaryPatternSyntax : PatternSyntax
{
    public UnaryPatternSyntax()
    {
        OperatorToken = null!;
        Pattern = null!;
        Parent = null;
    }

    public UnaryPatternSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.UnaryPatternSyntax node, SyntaxNode? parent)
    {
        OperatorToken = Cloner.ToToken(node.OperatorToken);
        Pattern = PatternSyntax.From(node.Pattern, this);
        Parent = parent;
    }

    public SyntaxToken OperatorToken { get; init; }
    public PatternSyntax Pattern { get; init; }
    public SyntaxNode? Parent { get; init; }
}
