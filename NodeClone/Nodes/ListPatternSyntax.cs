namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ListPatternSyntax : PatternSyntax
{
    public ListPatternSyntax()
    {
        OpenBracketToken = null!;
        Patterns = null!;
        CloseBracketToken = null!;
        Designation = null!;
        Parent = null;
    }

    public ListPatternSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ListPatternSyntax node, SyntaxNode? parent)
    {
        OpenBracketToken = Cloner.ToToken(node.OpenBracketToken);
        Patterns = Cloner.SeparatedListFrom<PatternSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax>(node.Patterns, this);
        CloseBracketToken = Cloner.ToToken(node.CloseBracketToken);
        Designation = node.Designation is null ? null : VariableDesignationSyntax.From(node.Designation, this);
        Parent = parent;
    }

    public SyntaxToken OpenBracketToken { get; init; }
    public SeparatedSyntaxList<PatternSyntax> Patterns { get; init; }
    public SyntaxToken CloseBracketToken { get; init; }
    public VariableDesignationSyntax? Designation { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        OpenBracketToken.AppendTo(stringBuilder);
        Patterns.AppendTo(stringBuilder);
        CloseBracketToken.AppendTo(stringBuilder);
        Designation?.AppendTo(stringBuilder);
    }
}
