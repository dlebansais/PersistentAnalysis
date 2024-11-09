namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonDerivedType(typeof(CasePatternSwitchLabelSyntax))]
[JsonDerivedType(typeof(CaseSwitchLabelSyntax))]
[JsonDerivedType(typeof(DefaultSwitchLabelSyntax))]
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
