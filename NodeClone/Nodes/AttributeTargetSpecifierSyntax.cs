namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class AttributeTargetSpecifierSyntax : SyntaxNode
{
    public AttributeTargetSpecifierSyntax()
    {
        Identifier = null!;
        ColonToken = null!;
        Parent = null;
    }

    public AttributeTargetSpecifierSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.AttributeTargetSpecifierSyntax node, SyntaxNode? parent)
    {
        Identifier = Cloner.ToToken(node.Identifier);
        ColonToken = Cloner.ToToken(node.ColonToken);
        Parent = parent;
    }

    public SyntaxToken Identifier { get; init; }
    public SyntaxToken ColonToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Identifier.AppendTo(stringBuilder);
        ColonToken.AppendTo(stringBuilder);
    }
}
