namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(ForEachStatementSyntax), typeDiscriminator: "ForEachStatementSyntax")]
[JsonDerivedType(typeof(ForEachVariableStatementSyntax), typeDiscriminator: "ForEachVariableStatementSyntax")]
public abstract class CommonForEachStatementSyntax : StatementSyntax
{
    public static CommonForEachStatementSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.CommonForEachStatementSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.ForEachStatementSyntax AsForEachStatementSyntax => new ForEachStatementSyntax(AsForEachStatementSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax AsForEachVariableStatementSyntax => new ForEachVariableStatementSyntax(AsForEachVariableStatementSyntax, parent),
            _ => null!,
        };
    }
}
