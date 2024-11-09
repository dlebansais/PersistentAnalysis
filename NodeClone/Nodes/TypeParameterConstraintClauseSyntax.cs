namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class TypeParameterConstraintClauseSyntax : SyntaxNode
{
    public TypeParameterConstraintClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintClauseSyntax node, SyntaxNode? parent)
    {
        WhereKeyword = Cloner.ToToken(node.WhereKeyword);
        Name = new IdentifierNameSyntax(node.Name, this);
        ColonToken = Cloner.ToToken(node.ColonToken);
        Constraints = Cloner.SeparatedListFrom<TypeParameterConstraintSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintSyntax>(node.Constraints, parent);
        Parent = parent;
    }

    public SyntaxToken WhereKeyword { get; }
    public IdentifierNameSyntax Name { get; }
    public SyntaxToken ColonToken { get; }
    public SeparatedSyntaxList<TypeParameterConstraintSyntax> Constraints { get; }
    public SyntaxNode? Parent { get; }
}
