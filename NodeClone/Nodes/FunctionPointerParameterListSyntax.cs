namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class FunctionPointerParameterListSyntax : SyntaxNode
{
    public FunctionPointerParameterListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.FunctionPointerParameterListSyntax node, SyntaxNode? parent)
    {
        LessThanToken = Cloner.ToToken(node.LessThanToken);
        Parameters = Cloner.SeparatedListFrom<FunctionPointerParameterSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.FunctionPointerParameterSyntax>(node.Parameters, parent);
        GreaterThanToken = Cloner.ToToken(node.GreaterThanToken);
        Parent = parent;
    }

    public SyntaxToken LessThanToken { get; }
    public SeparatedSyntaxList<FunctionPointerParameterSyntax> Parameters { get; }
    public SyntaxToken GreaterThanToken { get; }
    public SyntaxNode? Parent { get; }
}
