namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(ConstructorDeclarationSyntax), typeDiscriminator: "ConstructorDeclarationSyntax")]
[JsonDerivedType(typeof(ConversionOperatorDeclarationSyntax), typeDiscriminator: "ConversionOperatorDeclarationSyntax")]
[JsonDerivedType(typeof(DestructorDeclarationSyntax), typeDiscriminator: "DestructorDeclarationSyntax")]
[JsonDerivedType(typeof(MethodDeclarationSyntax), typeDiscriminator: "MethodDeclarationSyntax")]
[JsonDerivedType(typeof(OperatorDeclarationSyntax), typeDiscriminator: "OperatorDeclarationSyntax")]
public abstract class BaseMethodDeclarationSyntax : MemberDeclarationSyntax
{
    public static BaseMethodDeclarationSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.BaseMethodDeclarationSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.ConstructorDeclarationSyntax AsConstructorDeclarationSyntax => new ConstructorDeclarationSyntax(AsConstructorDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ConversionOperatorDeclarationSyntax AsConversionOperatorDeclarationSyntax => new ConversionOperatorDeclarationSyntax(AsConversionOperatorDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.DestructorDeclarationSyntax AsDestructorDeclarationSyntax => new DestructorDeclarationSyntax(AsDestructorDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.MethodDeclarationSyntax AsMethodDeclarationSyntax => new MethodDeclarationSyntax(AsMethodDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.OperatorDeclarationSyntax AsOperatorDeclarationSyntax => new OperatorDeclarationSyntax(AsOperatorDeclarationSyntax, parent),
            _ => null!,
        };
    }
}
