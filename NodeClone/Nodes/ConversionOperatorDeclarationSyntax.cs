namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ConversionOperatorDeclarationSyntax : BaseMethodDeclarationSyntax
{
    public ConversionOperatorDeclarationSyntax()
    {
        AttributeLists = null!;
        ImplicitOrExplicitKeyword = null!;
        ExplicitInterfaceSpecifier = null!;
        OperatorKeyword = null!;
        CheckedKeyword = null!;
        Type = null!;
        ParameterList = null!;
        Body = null!;
        ExpressionBody = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public ConversionOperatorDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ConversionOperatorDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        ImplicitOrExplicitKeyword = Cloner.ToToken(node.ImplicitOrExplicitKeyword);
        ExplicitInterfaceSpecifier = node.ExplicitInterfaceSpecifier is null ? null : new ExplicitInterfaceSpecifierSyntax(node.ExplicitInterfaceSpecifier, this);
        OperatorKeyword = Cloner.ToToken(node.OperatorKeyword);
        CheckedKeyword = Cloner.ToToken(node.CheckedKeyword);
        Type = TypeSyntax.From(node.Type, this);
        ParameterList = new ParameterListSyntax(node.ParameterList, this);
        Body = node.Body is null ? null : new BlockSyntax(node.Body, this);
        ExpressionBody = node.ExpressionBody is null ? null : new ArrowExpressionClauseSyntax(node.ExpressionBody, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken ImplicitOrExplicitKeyword { get; init; }
    public ExplicitInterfaceSpecifierSyntax? ExplicitInterfaceSpecifier { get; init; }
    public SyntaxToken OperatorKeyword { get; init; }
    public SyntaxToken CheckedKeyword { get; init; }
    public TypeSyntax Type { get; init; }
    public ParameterListSyntax ParameterList { get; init; }
    public BlockSyntax? Body { get; init; }
    public ArrowExpressionClauseSyntax? ExpressionBody { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
