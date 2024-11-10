namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class IndexerDeclarationSyntax : BasePropertyDeclarationSyntax
{
    public IndexerDeclarationSyntax()
    {
        AttributeLists = null!;
        Type = null!;
        ExplicitInterfaceSpecifier = null!;
        ThisKeyword = null!;
        ParameterList = null!;
        AccessorList = null!;
        ExpressionBody = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public IndexerDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.IndexerDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        Type = TypeSyntax.From(node.Type, this);
        ExplicitInterfaceSpecifier = node.ExplicitInterfaceSpecifier is null ? null : new ExplicitInterfaceSpecifierSyntax(node.ExplicitInterfaceSpecifier, this);
        ThisKeyword = Cloner.ToToken(node.ThisKeyword);
        ParameterList = new BracketedParameterListSyntax(node.ParameterList, this);
        AccessorList = node.AccessorList is null ? null : new AccessorListSyntax(node.AccessorList, this);
        ExpressionBody = node.ExpressionBody is null ? null : new ArrowExpressionClauseSyntax(node.ExpressionBody, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public TypeSyntax Type { get; init; }
    public ExplicitInterfaceSpecifierSyntax? ExplicitInterfaceSpecifier { get; init; }
    public SyntaxToken ThisKeyword { get; init; }
    public BracketedParameterListSyntax ParameterList { get; init; }
    public AccessorListSyntax? AccessorList { get; init; }
    public ArrowExpressionClauseSyntax? ExpressionBody { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
