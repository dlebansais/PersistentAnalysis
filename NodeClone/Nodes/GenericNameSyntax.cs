namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class GenericNameSyntax : SimpleNameSyntax
{
    public GenericNameSyntax()
    {
        Identifier = null!;
        TypeArgumentList = null!;
        Parent = null;
    }

    public GenericNameSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.GenericNameSyntax node, SyntaxNode? parent)
    {
        Identifier = Cloner.ToToken(node.Identifier);
        TypeArgumentList = new TypeArgumentListSyntax(node.TypeArgumentList, this);
        Parent = parent;
    }

    public SyntaxToken Identifier { get; init; }
    public TypeArgumentListSyntax TypeArgumentList { get; init; }
    public SyntaxNode? Parent { get; init; }
}
