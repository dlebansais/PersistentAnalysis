namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ScopedTypeSyntax : TypeSyntax
{
    public ScopedTypeSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ScopedTypeSyntax node, SyntaxNode? parent)
    {
        ScopedKeyword = Cloner.ToToken(node.ScopedKeyword);
        Type = TypeSyntax.From(node.Type, this);
        Parent = parent;
    }

    public SyntaxToken ScopedKeyword { get; }
    public TypeSyntax Type { get; }
    public SyntaxNode? Parent { get; }
}
