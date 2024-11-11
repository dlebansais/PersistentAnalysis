namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class FunctionPointerParameterListSyntax : SyntaxNode
{
    public FunctionPointerParameterListSyntax()
    {
        LessThanToken = null!;
        Parameters = null!;
        GreaterThanToken = null!;
        Parent = null;
    }

    public FunctionPointerParameterListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.FunctionPointerParameterListSyntax node, SyntaxNode? parent)
    {
        LessThanToken = Cloner.ToToken(node.LessThanToken);
        Parameters = Cloner.SeparatedListFrom<FunctionPointerParameterSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.FunctionPointerParameterSyntax>(node.Parameters, this);
        GreaterThanToken = Cloner.ToToken(node.GreaterThanToken);
        Parent = parent;
    }

    public SyntaxToken LessThanToken { get; init; }
    public SeparatedSyntaxList<FunctionPointerParameterSyntax> Parameters { get; init; }
    public SyntaxToken GreaterThanToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
