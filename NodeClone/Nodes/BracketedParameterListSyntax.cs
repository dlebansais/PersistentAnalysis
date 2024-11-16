namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class BracketedParameterListSyntax : BaseParameterListSyntax
{
    public BracketedParameterListSyntax()
    {
        OpenBracketToken = null!;
        Parameters = null!;
        CloseBracketToken = null!;
        Parent = null;
    }

    public BracketedParameterListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.BracketedParameterListSyntax node, SyntaxNode? parent)
    {
        OpenBracketToken = Cloner.ToToken(node.OpenBracketToken);
        Parameters = Cloner.SeparatedListFrom<ParameterSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.ParameterSyntax>(node.Parameters, this);
        CloseBracketToken = Cloner.ToToken(node.CloseBracketToken);
        Parent = parent;
    }

    public SyntaxToken OpenBracketToken { get; init; }
    public SeparatedSyntaxList<ParameterSyntax> Parameters { get; init; }
    public SyntaxToken CloseBracketToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        OpenBracketToken.AppendTo(stringBuilder);
        Parameters.AppendTo(stringBuilder);
        CloseBracketToken.AppendTo(stringBuilder);
    }
}
