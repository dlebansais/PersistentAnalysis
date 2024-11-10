namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(FromClauseSyntax), typeDiscriminator: "FromClauseSyntax")]
[JsonDerivedType(typeof(LetClauseSyntax), typeDiscriminator: "LetClauseSyntax")]
[JsonDerivedType(typeof(JoinClauseSyntax), typeDiscriminator: "JoinClauseSyntax")]
[JsonDerivedType(typeof(WhereClauseSyntax), typeDiscriminator: "WhereClauseSyntax")]
[JsonDerivedType(typeof(OrderByClauseSyntax), typeDiscriminator: "OrderByClauseSyntax")]
public abstract class QueryClauseSyntax : SyntaxNode
{
    public static QueryClauseSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.QueryClauseSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.FromClauseSyntax AsFromClauseSyntax => new FromClauseSyntax(AsFromClauseSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.LetClauseSyntax AsLetClauseSyntax => new LetClauseSyntax(AsLetClauseSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.JoinClauseSyntax AsJoinClauseSyntax => new JoinClauseSyntax(AsJoinClauseSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.WhereClauseSyntax AsWhereClauseSyntax => new WhereClauseSyntax(AsWhereClauseSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.OrderByClauseSyntax AsOrderByClauseSyntax => new OrderByClauseSyntax(AsOrderByClauseSyntax, parent),
            _ => null!,
        };
    }
}
