namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ParameterListSyntax : BaseParameterListSyntax
{
    public ParameterListSyntax()
    {
        OpenParenToken = null!;
        Parameters = null!;
        CloseParenToken = null!;
        Parent = null;
    }

    public ParameterListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ParameterListSyntax node, SyntaxNode? parent)
    {
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Parameters = Cloner.SeparatedListFrom<ParameterSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.ParameterSyntax>(node.Parameters, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken OpenParenToken { get; init; }
    public SeparatedSyntaxList<ParameterSyntax> Parameters { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        OpenParenToken.AppendTo(stringBuilder);
        Parameters.AppendTo(stringBuilder);
        CloseParenToken.AppendTo(stringBuilder);
    }
}
