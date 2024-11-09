namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonDerivedType(typeof(ParenthesizedLambdaExpressionSyntax))]
[JsonDerivedType(typeof(SimpleLambdaExpressionSyntax))]
public abstract class LambdaExpressionSyntax : AnonymousFunctionExpressionSyntax
{
    public static LambdaExpressionSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedLambdaExpressionSyntax AsParenthesizedLambdaExpressionSyntax => new ParenthesizedLambdaExpressionSyntax(AsParenthesizedLambdaExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.SimpleLambdaExpressionSyntax AsSimpleLambdaExpressionSyntax => new SimpleLambdaExpressionSyntax(AsSimpleLambdaExpressionSyntax, parent),
            _ => null!,
        };
    }
}
