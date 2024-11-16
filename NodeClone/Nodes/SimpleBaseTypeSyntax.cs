namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class SimpleBaseTypeSyntax : BaseTypeSyntax
{
    public SimpleBaseTypeSyntax()
    {
        Type = null!;
        Parent = null;
    }

    public SimpleBaseTypeSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.SimpleBaseTypeSyntax node, SyntaxNode? parent)
    {
        Type = TypeSyntax.From(node.Type, this);
        Parent = parent;
    }

    public TypeSyntax Type { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Type.AppendTo(stringBuilder);
    }
}
