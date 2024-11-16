namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class DefaultSwitchLabelSyntax : SwitchLabelSyntax
{
    public DefaultSwitchLabelSyntax()
    {
        Keyword = null!;
        ColonToken = null!;
        Parent = null;
    }

    public DefaultSwitchLabelSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.DefaultSwitchLabelSyntax node, SyntaxNode? parent)
    {
        Keyword = Cloner.ToToken(node.Keyword);
        ColonToken = Cloner.ToToken(node.ColonToken);
        Parent = parent;
    }

    public SyntaxToken Keyword { get; init; }
    public SyntaxToken ColonToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Keyword.AppendTo(stringBuilder);
        ColonToken.AppendTo(stringBuilder);
    }
}
