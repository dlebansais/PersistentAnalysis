namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ClassDeclarationSyntax : TypeDeclarationSyntax
{
    public ClassDeclarationSyntax()
    {
        AttributeLists = null!;
        Keyword = null!;
        Identifier = null!;
        TypeParameterList = null!;
        ParameterList = null!;
        BaseList = null!;
        ConstraintClauses = null!;
        OpenBraceToken = null!;
        Members = null!;
        CloseBraceToken = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public ClassDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        Keyword = Cloner.ToToken(node.Keyword);
        Identifier = Cloner.ToToken(node.Identifier);
        TypeParameterList = node.TypeParameterList is null ? null : new TypeParameterListSyntax(node.TypeParameterList, this);
        ParameterList = node.ParameterList is null ? null : new ParameterListSyntax(node.ParameterList, this);
        BaseList = node.BaseList is null ? null : new BaseListSyntax(node.BaseList, this);
        ConstraintClauses = Cloner.ListFrom<TypeParameterConstraintClauseSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintClauseSyntax>(node.ConstraintClauses, parent);
        OpenBraceToken = Cloner.ToToken(node.OpenBraceToken);
        Members = Cloner.ListFrom<MemberDeclarationSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax>(node.Members, parent);
        CloseBraceToken = Cloner.ToToken(node.CloseBraceToken);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken Keyword { get; init; }
    public SyntaxToken Identifier { get; init; }
    public TypeParameterListSyntax? TypeParameterList { get; init; }
    public ParameterListSyntax? ParameterList { get; init; }
    public BaseListSyntax? BaseList { get; init; }
    public SyntaxList<TypeParameterConstraintClauseSyntax> ConstraintClauses { get; init; }
    public SyntaxToken OpenBraceToken { get; init; }
    public SyntaxList<MemberDeclarationSyntax> Members { get; init; }
    public SyntaxToken CloseBraceToken { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
