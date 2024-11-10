namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class DefaultConstraintSyntax : TypeParameterConstraintSyntax
{
    public DefaultConstraintSyntax()
    {
        DefaultKeyword = null!;
        Parent = null;
    }

    public DefaultConstraintSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.DefaultConstraintSyntax node, SyntaxNode? parent)
    {
        DefaultKeyword = Cloner.ToToken(node.DefaultKeyword);
        Parent = parent;
    }

    public SyntaxToken DefaultKeyword { get; init; }
    public SyntaxNode? Parent { get; init; }
}
