namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class CollectionExpressionSyntax : ExpressionSyntax
{
    public CollectionExpressionSyntax()
    {
        OpenBracketToken = null!;
        Elements = null!;
        CloseBracketToken = null!;
        Parent = null;
    }

    public CollectionExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.CollectionExpressionSyntax node, SyntaxNode? parent)
    {
        OpenBracketToken = Cloner.ToToken(node.OpenBracketToken);
        Elements = Cloner.SeparatedListFrom<CollectionElementSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.CollectionElementSyntax>(node.Elements, this);
        CloseBracketToken = Cloner.ToToken(node.CloseBracketToken);
        Parent = parent;
    }

    public SyntaxToken OpenBracketToken { get; init; }
    public SeparatedSyntaxList<CollectionElementSyntax> Elements { get; init; }
    public SyntaxToken CloseBracketToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
