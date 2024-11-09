namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class TypeParameterListSyntax : SyntaxNode
{
    public TypeParameterListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterListSyntax node, SyntaxNode? parent)
    {
        LessThanToken = Cloner.ToToken(node.LessThanToken);
        Parameters = Cloner.SeparatedListFrom<TypeParameterSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterSyntax>(node.Parameters, parent);
        GreaterThanToken = Cloner.ToToken(node.GreaterThanToken);
        Parent = parent;
    }

    public SyntaxToken LessThanToken { get; }
    public SeparatedSyntaxList<TypeParameterSyntax> Parameters { get; }
    public SyntaxToken GreaterThanToken { get; }
    public SyntaxNode? Parent { get; }
}
