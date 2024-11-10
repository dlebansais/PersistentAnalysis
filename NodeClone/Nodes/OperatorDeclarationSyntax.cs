namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class OperatorDeclarationSyntax : BaseMethodDeclarationSyntax
{
    public OperatorDeclarationSyntax()
    {
        AttributeLists = null!;
        ReturnType = null!;
        ExplicitInterfaceSpecifier = null!;
        OperatorKeyword = null!;
        CheckedKeyword = null!;
        OperatorToken = null!;
        ParameterList = null!;
        Body = null!;
        ExpressionBody = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public OperatorDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.OperatorDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        ReturnType = TypeSyntax.From(node.ReturnType, this);
        ExplicitInterfaceSpecifier = node.ExplicitInterfaceSpecifier is null ? null : new ExplicitInterfaceSpecifierSyntax(node.ExplicitInterfaceSpecifier, this);
        OperatorKeyword = Cloner.ToToken(node.OperatorKeyword);
        CheckedKeyword = Cloner.ToToken(node.CheckedKeyword);
        OperatorToken = Cloner.ToToken(node.OperatorToken);
        ParameterList = new ParameterListSyntax(node.ParameterList, this);
        Body = node.Body is null ? null : new BlockSyntax(node.Body, this);
        ExpressionBody = node.ExpressionBody is null ? null : new ArrowExpressionClauseSyntax(node.ExpressionBody, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public TypeSyntax ReturnType { get; init; }
    public ExplicitInterfaceSpecifierSyntax? ExplicitInterfaceSpecifier { get; init; }
    public SyntaxToken OperatorKeyword { get; init; }
    public SyntaxToken CheckedKeyword { get; init; }
    public SyntaxToken OperatorToken { get; init; }
    public ParameterListSyntax ParameterList { get; init; }
    public BlockSyntax? Body { get; init; }
    public ArrowExpressionClauseSyntax? ExpressionBody { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
