namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class CasePatternSwitchLabelSyntax : SwitchLabelSyntax
{
    public CasePatternSwitchLabelSyntax()
    {
        Keyword = null!;
        Pattern = null!;
        WhenClause = null!;
        ColonToken = null!;
        Parent = null;
    }

    public CasePatternSwitchLabelSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.CasePatternSwitchLabelSyntax node, SyntaxNode? parent)
    {
        Keyword = Cloner.ToToken(node.Keyword);
        Pattern = PatternSyntax.From(node.Pattern, this);
        WhenClause = node.WhenClause is null ? null : new WhenClauseSyntax(node.WhenClause, this);
        ColonToken = Cloner.ToToken(node.ColonToken);
        Parent = parent;
    }

    public SyntaxToken Keyword { get; init; }
    public PatternSyntax Pattern { get; init; }
    public WhenClauseSyntax? WhenClause { get; init; }
    public SyntaxToken ColonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
