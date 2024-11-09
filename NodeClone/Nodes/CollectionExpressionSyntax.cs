namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class CollectionExpressionSyntax : ExpressionSyntax
{
    public CollectionExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.CollectionExpressionSyntax node, SyntaxNode? parent)
    {
        OpenBracketToken = Cloner.ToToken(node.OpenBracketToken);
        Elements = Cloner.SeparatedListFrom<CollectionElementSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.CollectionElementSyntax>(node.Elements, parent);
        CloseBracketToken = Cloner.ToToken(node.CloseBracketToken);
        Parent = parent;
    }

    public SyntaxToken OpenBracketToken { get; }
    public SeparatedSyntaxList<CollectionElementSyntax> Elements { get; }
    public SyntaxToken CloseBracketToken { get; }
    public SyntaxNode? Parent { get; }
}
