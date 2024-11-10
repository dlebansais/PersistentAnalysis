namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class SubpatternSyntax : SyntaxNode
{
    public SubpatternSyntax()
    {
        NameColon = null!;
        ExpressionColon = null!;
        Pattern = null!;
        Parent = null;
    }

    public SubpatternSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.SubpatternSyntax node, SyntaxNode? parent)
    {
        NameColon = node.NameColon is null ? null : new NameColonSyntax(node.NameColon, this);
        ExpressionColon = node.ExpressionColon is null ? null : BaseExpressionColonSyntax.From(node.ExpressionColon, this);
        Pattern = PatternSyntax.From(node.Pattern, this);
        Parent = parent;
    }

    public NameColonSyntax? NameColon { get; init; }
    public BaseExpressionColonSyntax? ExpressionColon { get; init; }
    public PatternSyntax Pattern { get; init; }
    public SyntaxNode? Parent { get; init; }
}
