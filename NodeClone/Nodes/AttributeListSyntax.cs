namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class AttributeListSyntax : SyntaxNode
{
    public AttributeListSyntax()
    {
        OpenBracketToken = null!;
        Target = null!;
        Attributes = null!;
        CloseBracketToken = null!;
        Parent = null;
    }

    public AttributeListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax node, SyntaxNode? parent)
    {
        OpenBracketToken = Cloner.ToToken(node.OpenBracketToken);
        Target = node.Target is null ? null : new AttributeTargetSpecifierSyntax(node.Target, this);
        Attributes = Cloner.SeparatedListFrom<AttributeSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeSyntax>(node.Attributes, this);
        CloseBracketToken = Cloner.ToToken(node.CloseBracketToken);
        Parent = parent;
    }

    public SyntaxToken OpenBracketToken { get; init; }
    public AttributeTargetSpecifierSyntax? Target { get; init; }
    public SeparatedSyntaxList<AttributeSyntax> Attributes { get; init; }
    public SyntaxToken CloseBracketToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
