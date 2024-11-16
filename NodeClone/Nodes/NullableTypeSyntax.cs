namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class NullableTypeSyntax : TypeSyntax
{
    public NullableTypeSyntax()
    {
        ElementType = null!;
        QuestionToken = null!;
        Parent = null;
    }

    public NullableTypeSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.NullableTypeSyntax node, SyntaxNode? parent)
    {
        ElementType = TypeSyntax.From(node.ElementType, this);
        QuestionToken = Cloner.ToToken(node.QuestionToken);
        Parent = parent;
    }

    public TypeSyntax ElementType { get; init; }
    public SyntaxToken QuestionToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        ElementType.AppendTo(stringBuilder);
        QuestionToken.AppendTo(stringBuilder);
    }
}
