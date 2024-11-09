namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class DefaultSwitchLabelSyntax : SwitchLabelSyntax
{
    public DefaultSwitchLabelSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.DefaultSwitchLabelSyntax node, SyntaxNode? parent)
    {
        Keyword = Cloner.ToToken(node.Keyword);
        ColonToken = Cloner.ToToken(node.ColonToken);
        Parent = parent;
    }

    public SyntaxToken Keyword { get; }
    public SyntaxToken ColonToken { get; }
    public SyntaxNode? Parent { get; }
}
