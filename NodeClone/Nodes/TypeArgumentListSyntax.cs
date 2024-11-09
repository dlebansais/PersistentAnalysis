namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class TypeArgumentListSyntax : SyntaxNode
{
    public TypeArgumentListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.TypeArgumentListSyntax node, SyntaxNode? parent)
    {
        LessThanToken = Cloner.ToToken(node.LessThanToken);
        Arguments = Cloner.SeparatedListFrom<TypeSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax>(node.Arguments, parent);
        GreaterThanToken = Cloner.ToToken(node.GreaterThanToken);
        Parent = parent;
    }

    public SyntaxToken LessThanToken { get; }
    public SeparatedSyntaxList<TypeSyntax> Arguments { get; }
    public SyntaxToken GreaterThanToken { get; }
    public SyntaxNode? Parent { get; }
}
