namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(CasePatternSwitchLabelSyntax), typeDiscriminator: "CasePatternSwitchLabelSyntax")]
[JsonDerivedType(typeof(CaseSwitchLabelSyntax), typeDiscriminator: "CaseSwitchLabelSyntax")]
[JsonDerivedType(typeof(DefaultSwitchLabelSyntax), typeDiscriminator: "DefaultSwitchLabelSyntax")]
public abstract class SwitchLabelSyntax : SyntaxNode
{
    public static SwitchLabelSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.SwitchLabelSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.CasePatternSwitchLabelSyntax AsCasePatternSwitchLabelSyntax => new CasePatternSwitchLabelSyntax(AsCasePatternSwitchLabelSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.CaseSwitchLabelSyntax AsCaseSwitchLabelSyntax => new CaseSwitchLabelSyntax(AsCaseSwitchLabelSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.DefaultSwitchLabelSyntax AsDefaultSwitchLabelSyntax => new DefaultSwitchLabelSyntax(AsDefaultSwitchLabelSyntax, parent),
            _ => null!,
        };
    }
}
