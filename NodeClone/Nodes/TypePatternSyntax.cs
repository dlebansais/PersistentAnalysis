namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class TypePatternSyntax : PatternSyntax
{
    public TypePatternSyntax()
    {
        Type = null!;
        Parent = null;
    }

    public TypePatternSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.TypePatternSyntax node, SyntaxNode? parent)
    {
        Type = TypeSyntax.From(node.Type, this);
        Parent = parent;
    }

    public TypeSyntax Type { get; init; }
    public SyntaxNode? Parent { get; init; }
}
