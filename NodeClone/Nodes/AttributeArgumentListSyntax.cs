namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class AttributeArgumentListSyntax : SyntaxNode
{
    public AttributeArgumentListSyntax()
    {
        OpenParenToken = null!;
        Arguments = null!;
        CloseParenToken = null!;
        Parent = null;
    }

    public AttributeArgumentListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.AttributeArgumentListSyntax node, SyntaxNode? parent)
    {
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Arguments = Cloner.SeparatedListFrom<AttributeArgumentSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeArgumentSyntax>(node.Arguments, parent);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken OpenParenToken { get; init; }
    public SeparatedSyntaxList<AttributeArgumentSyntax> Arguments { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
