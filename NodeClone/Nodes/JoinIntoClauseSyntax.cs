namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class JoinIntoClauseSyntax : SyntaxNode
{
    public JoinIntoClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.JoinIntoClauseSyntax node, SyntaxNode? parent)
    {
        IntoKeyword = Cloner.ToToken(node.IntoKeyword);
        Identifier = Cloner.ToToken(node.Identifier);
        Parent = parent;
    }

    public SyntaxToken IntoKeyword { get; }
    public SyntaxToken Identifier { get; }
    public SyntaxNode? Parent { get; }
}
