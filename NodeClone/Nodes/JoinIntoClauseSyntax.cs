namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class JoinIntoClauseSyntax : SyntaxNode
{
    public JoinIntoClauseSyntax()
    {
        IntoKeyword = null!;
        Identifier = null!;
        Parent = null;
    }

    public JoinIntoClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.JoinIntoClauseSyntax node, SyntaxNode? parent)
    {
        IntoKeyword = Cloner.ToToken(node.IntoKeyword);
        Identifier = Cloner.ToToken(node.Identifier);
        Parent = parent;
    }

    public SyntaxToken IntoKeyword { get; init; }
    public SyntaxToken Identifier { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        IntoKeyword.AppendTo(stringBuilder);
        Identifier.AppendTo(stringBuilder);
    }
}
