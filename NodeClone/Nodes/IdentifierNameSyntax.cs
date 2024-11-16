namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class IdentifierNameSyntax : SimpleNameSyntax
{
    public IdentifierNameSyntax()
    {
        Identifier = null!;
        Parent = null;
    }

    public IdentifierNameSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax node, SyntaxNode? parent)
    {
        Identifier = Cloner.ToToken(node.Identifier);
        Parent = parent;
    }

    public SyntaxToken Identifier { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Identifier.AppendTo(stringBuilder);
    }
}
