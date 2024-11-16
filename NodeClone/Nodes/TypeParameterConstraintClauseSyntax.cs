namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class TypeParameterConstraintClauseSyntax : SyntaxNode
{
    public TypeParameterConstraintClauseSyntax()
    {
        WhereKeyword = null!;
        Name = null!;
        ColonToken = null!;
        Constraints = null!;
        Parent = null;
    }

    public TypeParameterConstraintClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintClauseSyntax node, SyntaxNode? parent)
    {
        WhereKeyword = Cloner.ToToken(node.WhereKeyword);
        Name = new IdentifierNameSyntax(node.Name, this);
        ColonToken = Cloner.ToToken(node.ColonToken);
        Constraints = Cloner.SeparatedListFrom<TypeParameterConstraintSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintSyntax>(node.Constraints, this);
        Parent = parent;
    }

    public SyntaxToken WhereKeyword { get; init; }
    public IdentifierNameSyntax Name { get; init; }
    public SyntaxToken ColonToken { get; init; }
    public SeparatedSyntaxList<TypeParameterConstraintSyntax> Constraints { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        WhereKeyword.AppendTo(stringBuilder);
        Name.AppendTo(stringBuilder);
        ColonToken.AppendTo(stringBuilder);
        Constraints.AppendTo(stringBuilder);
    }
}
