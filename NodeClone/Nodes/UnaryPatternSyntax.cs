namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class UnaryPatternSyntax : PatternSyntax
{
    public UnaryPatternSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.UnaryPatternSyntax node, SyntaxNode? parent)
    {
        OperatorToken = Cloner.ToToken(node.OperatorToken);
        Pattern = PatternSyntax.From(node.Pattern, this);
        Parent = parent;
    }

    public SyntaxToken OperatorToken { get; }
    public PatternSyntax Pattern { get; }
    public SyntaxNode? Parent { get; }
}
