namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonDerivedType(typeof(SingleVariableDesignationSyntax))]
[JsonDerivedType(typeof(DiscardDesignationSyntax))]
[JsonDerivedType(typeof(ParenthesizedVariableDesignationSyntax))]
public abstract class VariableDesignationSyntax : SyntaxNode
{
    public static VariableDesignationSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.VariableDesignationSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.SingleVariableDesignationSyntax AsSingleVariableDesignationSyntax => new SingleVariableDesignationSyntax(AsSingleVariableDesignationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.DiscardDesignationSyntax AsDiscardDesignationSyntax => new DiscardDesignationSyntax(AsDiscardDesignationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedVariableDesignationSyntax AsParenthesizedVariableDesignationSyntax => new ParenthesizedVariableDesignationSyntax(AsParenthesizedVariableDesignationSyntax, parent),
            _ => null!,
        };
    }
}
