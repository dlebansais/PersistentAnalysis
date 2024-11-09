namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class AttributeTargetSpecifierSyntax : SyntaxNode
{
    public AttributeTargetSpecifierSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.AttributeTargetSpecifierSyntax node, SyntaxNode? parent)
    {
        Identifier = Cloner.ToToken(node.Identifier);
        ColonToken = Cloner.ToToken(node.ColonToken);
        Parent = parent;
    }

    public SyntaxToken Identifier { get; }
    public SyntaxToken ColonToken { get; }
    public SyntaxNode? Parent { get; }
}
