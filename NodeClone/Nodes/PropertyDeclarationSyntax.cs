namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class PropertyDeclarationSyntax : BasePropertyDeclarationSyntax
{
    public PropertyDeclarationSyntax()
    {
        AttributeLists = null!;
        Modifiers = null!;
        Type = null!;
        ExplicitInterfaceSpecifier = null!;
        Identifier = null!;
        AccessorList = null!;
        ExpressionBody = null!;
        Initializer = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public PropertyDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.PropertyDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        Modifiers = Cloner.ToTokenList(node.Modifiers);
        Type = TypeSyntax.From(node.Type, this);
        ExplicitInterfaceSpecifier = node.ExplicitInterfaceSpecifier is null ? null : new ExplicitInterfaceSpecifierSyntax(node.ExplicitInterfaceSpecifier, this);
        Identifier = Cloner.ToToken(node.Identifier);
        AccessorList = node.AccessorList is null ? null : new AccessorListSyntax(node.AccessorList, this);
        ExpressionBody = node.ExpressionBody is null ? null : new ArrowExpressionClauseSyntax(node.ExpressionBody, this);
        Initializer = node.Initializer is null ? null : new EqualsValueClauseSyntax(node.Initializer, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxTokenList Modifiers { get; init; }
    public TypeSyntax Type { get; init; }
    public ExplicitInterfaceSpecifierSyntax? ExplicitInterfaceSpecifier { get; init; }
    public SyntaxToken Identifier { get; init; }
    public AccessorListSyntax? AccessorList { get; init; }
    public ArrowExpressionClauseSyntax? ExpressionBody { get; init; }
    public EqualsValueClauseSyntax? Initializer { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        AttributeLists.AppendTo(stringBuilder);
        Modifiers.AppendTo(stringBuilder);
        Type.AppendTo(stringBuilder);
        ExplicitInterfaceSpecifier?.AppendTo(stringBuilder);
        Identifier.AppendTo(stringBuilder);
        AccessorList?.AppendTo(stringBuilder);
        ExpressionBody?.AppendTo(stringBuilder);
        Initializer?.AppendTo(stringBuilder);
        SemicolonToken.AppendTo(stringBuilder);
    }
}
