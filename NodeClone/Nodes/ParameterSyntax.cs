namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ParameterSyntax : BaseParameterSyntax
{
    public ParameterSyntax()
    {
        AttributeLists = null!;
        Type = null!;
        Identifier = null!;
        Default = null!;
        Parent = null;
    }

    public ParameterSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ParameterSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        Type = node.Type is null ? null : TypeSyntax.From(node.Type, this);
        Identifier = Cloner.ToToken(node.Identifier);
        Default = node.Default is null ? null : new EqualsValueClauseSyntax(node.Default, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public TypeSyntax? Type { get; init; }
    public SyntaxToken Identifier { get; init; }
    public EqualsValueClauseSyntax? Default { get; init; }
    public SyntaxNode? Parent { get; init; }
}
