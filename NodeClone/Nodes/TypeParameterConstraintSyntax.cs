namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(ClassOrStructConstraintSyntax), typeDiscriminator: "ClassOrStructConstraintSyntax")]
[JsonDerivedType(typeof(ConstructorConstraintSyntax), typeDiscriminator: "ConstructorConstraintSyntax")]
[JsonDerivedType(typeof(TypeConstraintSyntax), typeDiscriminator: "TypeConstraintSyntax")]
[JsonDerivedType(typeof(DefaultConstraintSyntax), typeDiscriminator: "DefaultConstraintSyntax")]
[JsonDerivedType(typeof(AllowsConstraintClauseSyntax), typeDiscriminator: "AllowsConstraintClauseSyntax")]
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
