namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class DelegateDeclarationSyntax : MemberDeclarationSyntax
{
    public DelegateDeclarationSyntax()
    {
        AttributeLists = null!;
        DelegateKeyword = null!;
        ReturnType = null!;
        Identifier = null!;
        TypeParameterList = null!;
        ParameterList = null!;
        ConstraintClauses = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public DelegateDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.DelegateDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        DelegateKeyword = Cloner.ToToken(node.DelegateKeyword);
        ReturnType = TypeSyntax.From(node.ReturnType, this);
        Identifier = Cloner.ToToken(node.Identifier);
        TypeParameterList = node.TypeParameterList is null ? null : new TypeParameterListSyntax(node.TypeParameterList, this);
        ParameterList = new ParameterListSyntax(node.ParameterList, this);
        ConstraintClauses = Cloner.ListFrom<TypeParameterConstraintClauseSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintClauseSyntax>(node.ConstraintClauses, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken DelegateKeyword { get; init; }
    public TypeSyntax ReturnType { get; init; }
    public SyntaxToken Identifier { get; init; }
    public TypeParameterListSyntax? TypeParameterList { get; init; }
    public ParameterListSyntax ParameterList { get; init; }
    public SyntaxList<TypeParameterConstraintClauseSyntax> ConstraintClauses { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
