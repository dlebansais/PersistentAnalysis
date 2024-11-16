namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class TupleElementSyntax : SyntaxNode
{
    public TupleElementSyntax()
    {
        Type = null!;
        Identifier = null!;
        Parent = null;
    }

    public TupleElementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.TupleElementSyntax node, SyntaxNode? parent)
    {
        Type = TypeSyntax.From(node.Type, this);
        Identifier = Cloner.ToToken(node.Identifier);
        Parent = parent;
    }

    public TypeSyntax Type { get; init; }
    public SyntaxToken Identifier { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Type.AppendTo(stringBuilder);
        Identifier.AppendTo(stringBuilder);
    }
}
