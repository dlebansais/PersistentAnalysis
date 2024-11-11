namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ArrayRankSpecifierSyntax : SyntaxNode
{
    public ArrayRankSpecifierSyntax()
    {
        OpenBracketToken = null!;
        Sizes = null!;
        CloseBracketToken = null!;
        Parent = null;
    }

    public ArrayRankSpecifierSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ArrayRankSpecifierSyntax node, SyntaxNode? parent)
    {
        OpenBracketToken = Cloner.ToToken(node.OpenBracketToken);
        Sizes = Cloner.SeparatedListFrom<ExpressionSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax>(node.Sizes, this);
        CloseBracketToken = Cloner.ToToken(node.CloseBracketToken);
        Parent = parent;
    }

    public SyntaxToken OpenBracketToken { get; init; }
    public SeparatedSyntaxList<ExpressionSyntax> Sizes { get; init; }
    public SyntaxToken CloseBracketToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
