namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class FieldDeclarationSyntax : BaseFieldDeclarationSyntax
{
    public FieldDeclarationSyntax()
    {
        AttributeLists = null!;
        Modifiers = null!;
        Declaration = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public FieldDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.FieldDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        Modifiers = Cloner.ToTokenList(node.Modifiers);
        Declaration = new VariableDeclarationSyntax(node.Declaration, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxTokenList Modifiers { get; init; }
    public VariableDeclarationSyntax Declaration { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        AttributeLists.AppendTo(stringBuilder);
        Modifiers.AppendTo(stringBuilder);
        Declaration.AppendTo(stringBuilder);
        SemicolonToken.AppendTo(stringBuilder);
    }
}
