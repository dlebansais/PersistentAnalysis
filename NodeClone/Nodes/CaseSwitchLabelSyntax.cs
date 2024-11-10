namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class CaseSwitchLabelSyntax : SwitchLabelSyntax
{
    public CaseSwitchLabelSyntax()
    {
        Keyword = null!;
        Value = null!;
        ColonToken = null!;
        Parent = null;
    }

    public CaseSwitchLabelSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.CaseSwitchLabelSyntax node, SyntaxNode? parent)
    {
        Keyword = Cloner.ToToken(node.Keyword);
        Value = ExpressionSyntax.From(node.Value, this);
        ColonToken = Cloner.ToToken(node.ColonToken);
        Parent = parent;
    }

    public SyntaxToken Keyword { get; init; }
    public ExpressionSyntax Value { get; init; }
    public SyntaxToken ColonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
