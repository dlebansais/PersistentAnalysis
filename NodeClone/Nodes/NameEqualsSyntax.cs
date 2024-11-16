namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class NameEqualsSyntax : SyntaxNode
{
    public NameEqualsSyntax()
    {
        Name = null!;
        EqualsToken = null!;
        Parent = null;
    }

    public NameEqualsSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.NameEqualsSyntax node, SyntaxNode? parent)
    {
        Name = new IdentifierNameSyntax(node.Name, this);
        EqualsToken = Cloner.ToToken(node.EqualsToken);
        Parent = parent;
    }

    public IdentifierNameSyntax Name { get; init; }
    public SyntaxToken EqualsToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Name.AppendTo(stringBuilder);
        EqualsToken.AppendTo(stringBuilder);
    }
}
