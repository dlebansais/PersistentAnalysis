namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class TypeArgumentListSyntax : SyntaxNode
{
    public TypeArgumentListSyntax()
    {
        LessThanToken = null!;
        Arguments = null!;
        GreaterThanToken = null!;
        Parent = null;
    }

    public TypeArgumentListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.TypeArgumentListSyntax node, SyntaxNode? parent)
    {
        LessThanToken = Cloner.ToToken(node.LessThanToken);
        Arguments = Cloner.SeparatedListFrom<TypeSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax>(node.Arguments, this);
        GreaterThanToken = Cloner.ToToken(node.GreaterThanToken);
        Parent = parent;
    }

    public SyntaxToken LessThanToken { get; init; }
    public SeparatedSyntaxList<TypeSyntax> Arguments { get; init; }
    public SyntaxToken GreaterThanToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        LessThanToken.AppendTo(stringBuilder);
        Arguments.AppendTo(stringBuilder);
        GreaterThanToken.AppendTo(stringBuilder);
    }
}
