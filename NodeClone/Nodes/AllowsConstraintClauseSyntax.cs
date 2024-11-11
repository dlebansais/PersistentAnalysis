namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class AllowsConstraintClauseSyntax : TypeParameterConstraintSyntax
{
    public AllowsConstraintClauseSyntax()
    {
        AllowsKeyword = null!;
        Constraints = null!;
        Parent = null;
    }

    public AllowsConstraintClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.AllowsConstraintClauseSyntax node, SyntaxNode? parent)
    {
        AllowsKeyword = Cloner.ToToken(node.AllowsKeyword);
        Constraints = Cloner.SeparatedListFrom<AllowsConstraintSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AllowsConstraintSyntax>(node.Constraints, this);
        Parent = parent;
    }

    public SyntaxToken AllowsKeyword { get; init; }
    public SeparatedSyntaxList<AllowsConstraintSyntax> Constraints { get; init; }
    public SyntaxNode? Parent { get; init; }
}
