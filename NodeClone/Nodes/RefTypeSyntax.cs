namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class RefTypeSyntax : TypeSyntax
{
    public RefTypeSyntax()
    {
        RefKeyword = null!;
        ReadOnlyKeyword = null!;
        Type = null!;
        Parent = null;
    }

    public RefTypeSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.RefTypeSyntax node, SyntaxNode? parent)
    {
        RefKeyword = Cloner.ToToken(node.RefKeyword);
        ReadOnlyKeyword = Cloner.ToToken(node.ReadOnlyKeyword);
        Type = TypeSyntax.From(node.Type, this);
        Parent = parent;
    }

    public SyntaxToken RefKeyword { get; init; }
    public SyntaxToken ReadOnlyKeyword { get; init; }
    public TypeSyntax Type { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        RefKeyword.AppendTo(stringBuilder);
        ReadOnlyKeyword.AppendTo(stringBuilder);
        Type.AppendTo(stringBuilder);
    }
}
