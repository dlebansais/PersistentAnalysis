namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class FunctionPointerParameterSyntax : BaseParameterSyntax
{
    public FunctionPointerParameterSyntax()
    {
        AttributeLists = null!;
        Type = null!;
        Parent = null;
    }

    public FunctionPointerParameterSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.FunctionPointerParameterSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        Type = TypeSyntax.From(node.Type, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public TypeSyntax Type { get; init; }
    public SyntaxNode? Parent { get; init; }
}
