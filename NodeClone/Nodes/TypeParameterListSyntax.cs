namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class TypeParameterListSyntax : SyntaxNode
{
    public TypeParameterListSyntax()
    {
        LessThanToken = null!;
        Parameters = null!;
        GreaterThanToken = null!;
        Parent = null;
    }

    public TypeParameterListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterListSyntax node, SyntaxNode? parent)
    {
        LessThanToken = Cloner.ToToken(node.LessThanToken);
        Parameters = Cloner.SeparatedListFrom<TypeParameterSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterSyntax>(node.Parameters, this);
        GreaterThanToken = Cloner.ToToken(node.GreaterThanToken);
        Parent = parent;
    }

    public SyntaxToken LessThanToken { get; init; }
    public SeparatedSyntaxList<TypeParameterSyntax> Parameters { get; init; }
    public SyntaxToken GreaterThanToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
