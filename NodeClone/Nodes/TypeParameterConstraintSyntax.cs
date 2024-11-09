namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonDerivedType(typeof(ClassOrStructConstraintSyntax))]
[JsonDerivedType(typeof(ConstructorConstraintSyntax))]
[JsonDerivedType(typeof(TypeConstraintSyntax))]
[JsonDerivedType(typeof(DefaultConstraintSyntax))]
[JsonDerivedType(typeof(AllowsConstraintClauseSyntax))]
public abstract class TypeParameterConstraintSyntax : SyntaxNode
{
    public static TypeParameterConstraintSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.ClassOrStructConstraintSyntax AsClassOrStructConstraintSyntax => new ClassOrStructConstraintSyntax(AsClassOrStructConstraintSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ConstructorConstraintSyntax AsConstructorConstraintSyntax => new ConstructorConstraintSyntax(AsConstructorConstraintSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.TypeConstraintSyntax AsTypeConstraintSyntax => new TypeConstraintSyntax(AsTypeConstraintSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.DefaultConstraintSyntax AsDefaultConstraintSyntax => new DefaultConstraintSyntax(AsDefaultConstraintSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.AllowsConstraintClauseSyntax AsAllowsConstraintClauseSyntax => new AllowsConstraintClauseSyntax(AsAllowsConstraintClauseSyntax, parent),
            _ => null!,
        };
    }
}
