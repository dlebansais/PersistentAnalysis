namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class DelegateDeclarationSyntax : MemberDeclarationSyntax
{
    public DelegateDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.DelegateDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        DelegateKeyword = Cloner.ToToken(node.DelegateKeyword);
        ReturnType = TypeSyntax.From(node.ReturnType, this);
        Identifier = Cloner.ToToken(node.Identifier);
        TypeParameterList = node.TypeParameterList is null ? null : new TypeParameterListSyntax(node.TypeParameterList, this);
        ParameterList = new ParameterListSyntax(node.ParameterList, this);
        ConstraintClauses = Cloner.ListFrom<TypeParameterConstraintClauseSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintClauseSyntax>(node.ConstraintClauses, parent);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; }
    public SyntaxToken DelegateKeyword { get; }
    public TypeSyntax ReturnType { get; }
    public SyntaxToken Identifier { get; }
    public TypeParameterListSyntax? TypeParameterList { get; }
    public ParameterListSyntax ParameterList { get; }
    public SyntaxList<TypeParameterConstraintClauseSyntax> ConstraintClauses { get; }
    public SyntaxToken SemicolonToken { get; }
    public SyntaxNode? Parent { get; }
}
