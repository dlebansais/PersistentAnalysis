namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class DestructorDeclarationSyntax : BaseMethodDeclarationSyntax
{
    public DestructorDeclarationSyntax()
    {
        AttributeLists = null!;
        Modifiers = null!;
        TildeToken = null!;
        Identifier = null!;
        ParameterList = null!;
        Body = null!;
        ExpressionBody = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public DestructorDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.DestructorDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        Modifiers = Cloner.ToTokenList(node.Modifiers);
        TildeToken = Cloner.ToToken(node.TildeToken);
        Identifier = Cloner.ToToken(node.Identifier);
        ParameterList = new ParameterListSyntax(node.ParameterList, this);
        Body = node.Body is null ? null : new BlockSyntax(node.Body, this);
        ExpressionBody = node.ExpressionBody is null ? null : new ArrowExpressionClauseSyntax(node.ExpressionBody, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxTokenList Modifiers { get; init; }
    public SyntaxToken TildeToken { get; init; }
    public SyntaxToken Identifier { get; init; }
    public ParameterListSyntax ParameterList { get; init; }
    public BlockSyntax? Body { get; init; }
    public ArrowExpressionClauseSyntax? ExpressionBody { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        AttributeLists.AppendTo(stringBuilder);
        Modifiers.AppendTo(stringBuilder);
        TildeToken.AppendTo(stringBuilder);
        Identifier.AppendTo(stringBuilder);
        ParameterList.AppendTo(stringBuilder);
        Body?.AppendTo(stringBuilder);
        ExpressionBody?.AppendTo(stringBuilder);
        SemicolonToken.AppendTo(stringBuilder);
    }
}
