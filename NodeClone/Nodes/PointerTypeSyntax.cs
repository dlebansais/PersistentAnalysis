namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class PointerTypeSyntax : TypeSyntax
{
    public PointerTypeSyntax()
    {
        ElementType = null!;
        AsteriskToken = null!;
        Parent = null;
    }

    public PointerTypeSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.PointerTypeSyntax node, SyntaxNode? parent)
    {
        ElementType = TypeSyntax.From(node.ElementType, this);
        AsteriskToken = Cloner.ToToken(node.AsteriskToken);
        Parent = parent;
    }

    public TypeSyntax ElementType { get; init; }
    public SyntaxToken AsteriskToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        ElementType.AppendTo(stringBuilder);
        AsteriskToken.AppendTo(stringBuilder);
    }
}
