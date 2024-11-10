namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(AnonymousMethodExpressionSyntax), typeDiscriminator: "AnonymousMethodExpressionSyntax")]
[JsonDerivedType(typeof(ParenthesizedLambdaExpressionSyntax), typeDiscriminator: "ParenthesizedLambdaExpressionSyntax")]
[JsonDerivedType(typeof(SimpleLambdaExpressionSyntax), typeDiscriminator: "SimpleLambdaExpressionSyntax")]
public abstract class AnonymousFunctionExpressionSyntax : ExpressionSyntax
{
    public static AnonymousFunctionExpressionSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousMethodExpressionSyntax AsAnonymousMethodExpressionSyntax => new AnonymousMethodExpressionSyntax(AsAnonymousMethodExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedLambdaExpressionSyntax AsParenthesizedLambdaExpressionSyntax => new ParenthesizedLambdaExpressionSyntax(AsParenthesizedLambdaExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.SimpleLambdaExpressionSyntax AsSimpleLambdaExpressionSyntax => new SimpleLambdaExpressionSyntax(AsSimpleLambdaExpressionSyntax, parent),
            _ => null!,
        };
    }
}
