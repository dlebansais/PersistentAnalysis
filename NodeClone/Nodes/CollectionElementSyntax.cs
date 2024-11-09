namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonDerivedType(typeof(ExpressionElementSyntax))]
[JsonDerivedType(typeof(SpreadElementSyntax))]
public abstract class CollectionElementSyntax : SyntaxNode
{
    public static CollectionElementSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.CollectionElementSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionElementSyntax AsExpressionElementSyntax => new ExpressionElementSyntax(AsExpressionElementSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.SpreadElementSyntax AsSpreadElementSyntax => new SpreadElementSyntax(AsSpreadElementSyntax, parent),
            _ => null!,
        };
    }
}
