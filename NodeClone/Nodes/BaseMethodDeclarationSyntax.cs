namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonDerivedType(typeof(ConstructorDeclarationSyntax))]
[JsonDerivedType(typeof(ConversionOperatorDeclarationSyntax))]
[JsonDerivedType(typeof(DestructorDeclarationSyntax))]
[JsonDerivedType(typeof(MethodDeclarationSyntax))]
[JsonDerivedType(typeof(OperatorDeclarationSyntax))]
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
