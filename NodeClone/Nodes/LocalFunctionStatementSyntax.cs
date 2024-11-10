namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class LocalFunctionStatementSyntax : StatementSyntax
{
    public LocalFunctionStatementSyntax()
    {
        AttributeLists = null!;
        ReturnType = null!;
        Identifier = null!;
        TypeParameterList = null!;
        ParameterList = null!;
        ConstraintClauses = null!;
        Body = null!;
        ExpressionBody = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public LocalFunctionStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.LocalFunctionStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        ReturnType = TypeSyntax.From(node.ReturnType, this);
        Identifier = Cloner.ToToken(node.Identifier);
        TypeParameterList = node.TypeParameterList is null ? null : new TypeParameterListSyntax(node.TypeParameterList, this);
        ParameterList = new ParameterListSyntax(node.ParameterList, this);
        ConstraintClauses = Cloner.ListFrom<TypeParameterConstraintClauseSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintClauseSyntax>(node.ConstraintClauses, parent);
        Body = node.Body is null ? null : new BlockSyntax(node.Body, this);
        ExpressionBody = node.ExpressionBody is null ? null : new ArrowExpressionClauseSyntax(node.ExpressionBody, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public TypeSyntax ReturnType { get; init; }
    public SyntaxToken Identifier { get; init; }
    public TypeParameterListSyntax? TypeParameterList { get; init; }
    public ParameterListSyntax ParameterList { get; init; }
    public SyntaxList<TypeParameterConstraintClauseSyntax> ConstraintClauses { get; init; }
    public BlockSyntax? Body { get; init; }
    public ArrowExpressionClauseSyntax? ExpressionBody { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
