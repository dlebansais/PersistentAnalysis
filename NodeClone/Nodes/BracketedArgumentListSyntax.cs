namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class BracketedArgumentListSyntax : BaseArgumentListSyntax
{
    public BracketedArgumentListSyntax()
    {
        OpenBracketToken = null!;
        Arguments = null!;
        CloseBracketToken = null!;
        Parent = null;
    }

    public BracketedArgumentListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.BracketedArgumentListSyntax node, SyntaxNode? parent)
    {
        OpenBracketToken = Cloner.ToToken(node.OpenBracketToken);
        Arguments = Cloner.SeparatedListFrom<ArgumentSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentSyntax>(node.Arguments, this);
        CloseBracketToken = Cloner.ToToken(node.CloseBracketToken);
        Parent = parent;
    }

    public SyntaxToken OpenBracketToken { get; init; }
    public SeparatedSyntaxList<ArgumentSyntax> Arguments { get; init; }
    public SyntaxToken CloseBracketToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
