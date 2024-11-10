namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(ParameterSyntax), typeDiscriminator: "ParameterSyntax")]
[JsonDerivedType(typeof(FunctionPointerParameterSyntax), typeDiscriminator: "FunctionPointerParameterSyntax")]
public abstract class BaseParameterSyntax : SyntaxNode
{
    public static BaseParameterSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.BaseParameterSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.ParameterSyntax AsParameterSyntax => new ParameterSyntax(AsParameterSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.FunctionPointerParameterSyntax AsFunctionPointerParameterSyntax => new FunctionPointerParameterSyntax(AsFunctionPointerParameterSyntax, parent),
            _ => null!,
        };
    }
}
