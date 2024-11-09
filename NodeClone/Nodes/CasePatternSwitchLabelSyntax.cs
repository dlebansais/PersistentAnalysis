namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class CasePatternSwitchLabelSyntax : SwitchLabelSyntax
{
    public CasePatternSwitchLabelSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.CasePatternSwitchLabelSyntax node, SyntaxNode? parent)
    {
        Keyword = Cloner.ToToken(node.Keyword);
        Pattern = PatternSyntax.From(node.Pattern, this);
        WhenClause = node.WhenClause is null ? null : new WhenClauseSyntax(node.WhenClause, this);
        ColonToken = Cloner.ToToken(node.ColonToken);
        Parent = parent;
    }

    public SyntaxToken Keyword { get; }
    public PatternSyntax Pattern { get; }
    public WhenClauseSyntax? WhenClause { get; }
    public SyntaxToken ColonToken { get; }
    public SyntaxNode? Parent { get; }
}
