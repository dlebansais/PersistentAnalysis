namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class PropertyPatternClauseSyntax : SyntaxNode
{
    public PropertyPatternClauseSyntax()
    {
        OpenBraceToken = null!;
        Subpatterns = null!;
        CloseBraceToken = null!;
        Parent = null;
    }

    public PropertyPatternClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.PropertyPatternClauseSyntax node, SyntaxNode? parent)
    {
        OpenBraceToken = Cloner.ToToken(node.OpenBraceToken);
        Subpatterns = Cloner.SeparatedListFrom<SubpatternSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.SubpatternSyntax>(node.Subpatterns, this);
        CloseBraceToken = Cloner.ToToken(node.CloseBraceToken);
        Parent = parent;
    }

    public SyntaxToken OpenBraceToken { get; init; }
    public SeparatedSyntaxList<SubpatternSyntax> Subpatterns { get; init; }
    public SyntaxToken CloseBraceToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        OpenBraceToken.AppendTo(stringBuilder);
        Subpatterns.AppendTo(stringBuilder);
        CloseBraceToken.AppendTo(stringBuilder);
    }
}
