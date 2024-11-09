namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class RecordDeclarationSyntax : TypeDeclarationSyntax
{
    public RecordDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.RecordDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        Keyword = Cloner.ToToken(node.Keyword);
        ClassOrStructKeyword = Cloner.ToToken(node.ClassOrStructKeyword);
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

    public SyntaxList<AttributeListSyntax> AttributeLists { get; }
    public SyntaxToken Keyword { get; }
    public SyntaxToken ClassOrStructKeyword { get; }
    public SyntaxToken Identifier { get; }
    public TypeParameterListSyntax? TypeParameterList { get; }
    public ParameterListSyntax? ParameterList { get; }
    public BaseListSyntax? BaseList { get; }
    public SyntaxList<TypeParameterConstraintClauseSyntax> ConstraintClauses { get; }
    public SyntaxToken OpenBraceToken { get; }
    public SyntaxList<MemberDeclarationSyntax> Members { get; }
    public SyntaxToken CloseBraceToken { get; }
    public SyntaxToken SemicolonToken { get; }
    public SyntaxNode? Parent { get; }
}
