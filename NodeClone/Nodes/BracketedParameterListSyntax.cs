namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class BracketedParameterListSyntax : BaseParameterListSyntax
{
    public BracketedParameterListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.BracketedParameterListSyntax node, SyntaxNode? parent)
    {
        OpenBracketToken = Cloner.ToToken(node.OpenBracketToken);
        Parameters = Cloner.SeparatedListFrom<ParameterSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.ParameterSyntax>(node.Parameters, parent);
        CloseBracketToken = Cloner.ToToken(node.CloseBracketToken);
        Parent = parent;
    }

    public SyntaxToken OpenBracketToken { get; }
    public SeparatedSyntaxList<ParameterSyntax> Parameters { get; }
    public SyntaxToken CloseBracketToken { get; }
    public SyntaxNode? Parent { get; }
}
