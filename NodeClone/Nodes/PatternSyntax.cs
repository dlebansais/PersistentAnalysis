namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(DiscardPatternSyntax), typeDiscriminator: "DiscardPatternSyntax")]
[JsonDerivedType(typeof(DeclarationPatternSyntax), typeDiscriminator: "DeclarationPatternSyntax")]
[JsonDerivedType(typeof(VarPatternSyntax), typeDiscriminator: "VarPatternSyntax")]
[JsonDerivedType(typeof(RecursivePatternSyntax), typeDiscriminator: "RecursivePatternSyntax")]
[JsonDerivedType(typeof(ConstantPatternSyntax), typeDiscriminator: "ConstantPatternSyntax")]
[JsonDerivedType(typeof(ParenthesizedPatternSyntax), typeDiscriminator: "ParenthesizedPatternSyntax")]
[JsonDerivedType(typeof(RelationalPatternSyntax), typeDiscriminator: "RelationalPatternSyntax")]
[JsonDerivedType(typeof(TypePatternSyntax), typeDiscriminator: "TypePatternSyntax")]
[JsonDerivedType(typeof(BinaryPatternSyntax), typeDiscriminator: "BinaryPatternSyntax")]
[JsonDerivedType(typeof(UnaryPatternSyntax), typeDiscriminator: "UnaryPatternSyntax")]
[JsonDerivedType(typeof(ListPatternSyntax), typeDiscriminator: "ListPatternSyntax")]
[JsonDerivedType(typeof(SlicePatternSyntax), typeDiscriminator: "SlicePatternSyntax")]
public abstract class PatternSyntax : ExpressionOrPatternSyntax
{
    public static PatternSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.DiscardPatternSyntax AsDiscardPatternSyntax => new DiscardPatternSyntax(AsDiscardPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.DeclarationPatternSyntax AsDeclarationPatternSyntax => new DeclarationPatternSyntax(AsDeclarationPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.VarPatternSyntax AsVarPatternSyntax => new VarPatternSyntax(AsVarPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.RecursivePatternSyntax AsRecursivePatternSyntax => new RecursivePatternSyntax(AsRecursivePatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ConstantPatternSyntax AsConstantPatternSyntax => new ConstantPatternSyntax(AsConstantPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedPatternSyntax AsParenthesizedPatternSyntax => new ParenthesizedPatternSyntax(AsParenthesizedPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.RelationalPatternSyntax AsRelationalPatternSyntax => new RelationalPatternSyntax(AsRelationalPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.TypePatternSyntax AsTypePatternSyntax => new TypePatternSyntax(AsTypePatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.BinaryPatternSyntax AsBinaryPatternSyntax => new BinaryPatternSyntax(AsBinaryPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.UnaryPatternSyntax AsUnaryPatternSyntax => new UnaryPatternSyntax(AsUnaryPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ListPatternSyntax AsListPatternSyntax => new ListPatternSyntax(AsListPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.SlicePatternSyntax AsSlicePatternSyntax => new SlicePatternSyntax(AsSlicePatternSyntax, parent),
            _ => null!,
        };
    }
}
