namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class RefStructConstraintSyntax : AllowsConstraintSyntax
{
    public RefStructConstraintSyntax()
    {
        RefKeyword = null!;
        StructKeyword = null!;
        Parent = null;
    }

    public RefStructConstraintSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.RefStructConstraintSyntax node, SyntaxNode? parent)
    {
        RefKeyword = Cloner.ToToken(node.RefKeyword);
        StructKeyword = Cloner.ToToken(node.StructKeyword);
        Parent = parent;
    }

    public SyntaxToken RefKeyword { get; init; }
    public SyntaxToken StructKeyword { get; init; }
    public SyntaxNode? Parent { get; init; }
}
