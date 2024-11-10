namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class PrimaryConstructorBaseTypeSyntax : BaseTypeSyntax
{
    public PrimaryConstructorBaseTypeSyntax()
    {
        Type = null!;
        ArgumentList = null!;
        Parent = null;
    }

    public PrimaryConstructorBaseTypeSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.PrimaryConstructorBaseTypeSyntax node, SyntaxNode? parent)
    {
        Type = TypeSyntax.From(node.Type, this);
        ArgumentList = new ArgumentListSyntax(node.ArgumentList, this);
        Parent = parent;
    }

    public TypeSyntax Type { get; init; }
    public ArgumentListSyntax ArgumentList { get; init; }
    public SyntaxNode? Parent { get; init; }
}
