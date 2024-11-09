namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ArgumentSyntax : SyntaxNode
{
    public ArgumentSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentSyntax node, SyntaxNode? parent)
    {
        RefOrOutKeyword = Cloner.ToToken(node.RefOrOutKeyword);
        NameColon = node.NameColon is null ? null : new NameColonSyntax(node.NameColon, this);
        RefKindKeyword = Cloner.ToToken(node.RefKindKeyword);
        Expression = ExpressionSyntax.From(node.Expression, this);
        Parent = parent;
    }

    public SyntaxToken RefOrOutKeyword { get; }
    public NameColonSyntax? NameColon { get; }
    public SyntaxToken RefKindKeyword { get; }
    public ExpressionSyntax Expression { get; }
    public SyntaxNode? Parent { get; }
}
