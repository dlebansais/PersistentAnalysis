namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(SelectClauseSyntax), typeDiscriminator: "SelectClauseSyntax")]
[JsonDerivedType(typeof(GroupClauseSyntax), typeDiscriminator: "GroupClauseSyntax")]
public abstract class SelectOrGroupClauseSyntax : SyntaxNode
{
    public static SelectOrGroupClauseSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.SelectOrGroupClauseSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.SelectClauseSyntax AsSelectClauseSyntax => new SelectClauseSyntax(AsSelectClauseSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.GroupClauseSyntax AsGroupClauseSyntax => new GroupClauseSyntax(AsGroupClauseSyntax, parent),
            _ => null!,
        };
    }
}
