namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class AccessorDeclarationSyntax : SyntaxNode
{
    public AccessorDeclarationSyntax()
    {
        AttributeLists = null!;
        Keyword = null!;
        Body = null!;
        ExpressionBody = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public AccessorDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.AccessorDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        Keyword = Cloner.ToToken(node.Keyword);
        Body = node.Body is null ? null : new BlockSyntax(node.Body, this);
        ExpressionBody = node.ExpressionBody is null ? null : new ArrowExpressionClauseSyntax(node.ExpressionBody, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken Keyword { get; init; }
    public BlockSyntax? Body { get; init; }
    public ArrowExpressionClauseSyntax? ExpressionBody { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
