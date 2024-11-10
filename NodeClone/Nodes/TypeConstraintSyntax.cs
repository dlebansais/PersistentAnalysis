namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class TypeConstraintSyntax : TypeParameterConstraintSyntax
{
    public TypeConstraintSyntax()
    {
        Type = null!;
        Parent = null;
    }

    public TypeConstraintSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.TypeConstraintSyntax node, SyntaxNode? parent)
    {
        Type = TypeSyntax.From(node.Type, this);
        Parent = parent;
    }

    public TypeSyntax Type { get; init; }
    public SyntaxNode? Parent { get; init; }
}
