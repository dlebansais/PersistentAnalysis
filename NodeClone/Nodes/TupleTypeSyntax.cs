namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class TupleTypeSyntax : TypeSyntax
{
    public TupleTypeSyntax()
    {
        OpenParenToken = null!;
        Elements = null!;
        CloseParenToken = null!;
        Parent = null;
    }

    public TupleTypeSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.TupleTypeSyntax node, SyntaxNode? parent)
    {
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Elements = Cloner.SeparatedListFrom<TupleElementSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.TupleElementSyntax>(node.Elements, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken OpenParenToken { get; init; }
    public SeparatedSyntaxList<TupleElementSyntax> Elements { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        OpenParenToken.AppendTo(stringBuilder);
        Elements.AppendTo(stringBuilder);
        CloseParenToken.AppendTo(stringBuilder);
    }
}
