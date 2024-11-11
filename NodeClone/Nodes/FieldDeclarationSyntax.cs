namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class FieldDeclarationSyntax : BaseFieldDeclarationSyntax
{
    public FieldDeclarationSyntax()
    {
        AttributeLists = null!;
        Declaration = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public FieldDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.FieldDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        Declaration = new VariableDeclarationSyntax(node.Declaration, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public VariableDeclarationSyntax Declaration { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
