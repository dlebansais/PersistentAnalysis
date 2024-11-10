namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class PositionalPatternClauseSyntax : SyntaxNode
{
    public PositionalPatternClauseSyntax()
    {
        OpenParenToken = null!;
        Subpatterns = null!;
        CloseParenToken = null!;
        Parent = null;
    }

    public PositionalPatternClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.PositionalPatternClauseSyntax node, SyntaxNode? parent)
    {
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Subpatterns = Cloner.SeparatedListFrom<SubpatternSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.SubpatternSyntax>(node.Subpatterns, parent);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken OpenParenToken { get; init; }
    public SeparatedSyntaxList<SubpatternSyntax> Subpatterns { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
