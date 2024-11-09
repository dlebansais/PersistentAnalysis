namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonDerivedType(typeof(NameColonSyntax))]
[JsonDerivedType(typeof(ExpressionColonSyntax))]
public abstract class BaseExpressionColonSyntax : SyntaxNode
{
    public static BaseExpressionColonSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.BaseExpressionColonSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.NameColonSyntax AsNameColonSyntax => new NameColonSyntax(AsNameColonSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionColonSyntax AsExpressionColonSyntax => new ExpressionColonSyntax(AsExpressionColonSyntax, parent),
            _ => null!,
        };
    }
}
