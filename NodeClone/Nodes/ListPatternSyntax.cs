namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ListPatternSyntax : PatternSyntax
{
    public ListPatternSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ListPatternSyntax node, SyntaxNode? parent)
    {
        OpenBracketToken = Cloner.ToToken(node.OpenBracketToken);
        Patterns = Cloner.SeparatedListFrom<PatternSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax>(node.Patterns, parent);
        CloseBracketToken = Cloner.ToToken(node.CloseBracketToken);
        Designation = node.Designation is null ? null : VariableDesignationSyntax.From(node.Designation, this);
        Parent = parent;
    }

    public SyntaxToken OpenBracketToken { get; }
    public SeparatedSyntaxList<PatternSyntax> Patterns { get; }
    public SyntaxToken CloseBracketToken { get; }
    public VariableDesignationSyntax? Designation { get; }
    public SyntaxNode? Parent { get; }
}
