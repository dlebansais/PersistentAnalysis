namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class PositionalPatternClauseSyntax : SyntaxNode
{
    public PositionalPatternClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.PositionalPatternClauseSyntax node, SyntaxNode? parent)
    {
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Subpatterns = Cloner.SeparatedListFrom<SubpatternSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.SubpatternSyntax>(node.Subpatterns, parent);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken OpenParenToken { get; }
    public SeparatedSyntaxList<SubpatternSyntax> Subpatterns { get; }
    public SyntaxToken CloseParenToken { get; }
    public SyntaxNode? Parent { get; }
}
