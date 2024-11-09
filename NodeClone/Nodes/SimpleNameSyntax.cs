namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonDerivedType(typeof(GenericNameSyntax))]
[JsonDerivedType(typeof(IdentifierNameSyntax))]
public abstract class SimpleNameSyntax : NameSyntax
{
    public static SimpleNameSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.SimpleNameSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.GenericNameSyntax AsGenericNameSyntax => new GenericNameSyntax(AsGenericNameSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax AsIdentifierNameSyntax => new IdentifierNameSyntax(AsIdentifierNameSyntax, parent),
            _ => null!,
        };
    }
}
