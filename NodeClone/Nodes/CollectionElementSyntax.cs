namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(ExpressionElementSyntax), typeDiscriminator: "ExpressionElementSyntax")]
[JsonDerivedType(typeof(SpreadElementSyntax), typeDiscriminator: "SpreadElementSyntax")]
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
