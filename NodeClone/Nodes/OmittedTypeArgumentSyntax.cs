namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class OmittedTypeArgumentSyntax : TypeSyntax
{
    public OmittedTypeArgumentSyntax()
    {
        OmittedTypeArgumentToken = null!;
        Parent = null;
    }

    public OmittedTypeArgumentSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.OmittedTypeArgumentSyntax node, SyntaxNode? parent)
    {
        OmittedTypeArgumentToken = Cloner.ToToken(node.OmittedTypeArgumentToken);
        Parent = parent;
    }

    public SyntaxToken OmittedTypeArgumentToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        OmittedTypeArgumentToken.AppendTo(stringBuilder);
    }
}
