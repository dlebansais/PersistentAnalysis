namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ScopedTypeSyntax : TypeSyntax
{
    public ScopedTypeSyntax()
    {
        ScopedKeyword = null!;
        Type = null!;
        Parent = null;
    }

    public ScopedTypeSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ScopedTypeSyntax node, SyntaxNode? parent)
    {
        ScopedKeyword = Cloner.ToToken(node.ScopedKeyword);
        Type = TypeSyntax.From(node.Type, this);
        Parent = parent;
    }

    public SyntaxToken ScopedKeyword { get; init; }
    public TypeSyntax Type { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        ScopedKeyword.AppendTo(stringBuilder);
        Type.AppendTo(stringBuilder);
    }
}
