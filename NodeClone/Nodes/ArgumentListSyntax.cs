namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ArgumentListSyntax : BaseArgumentListSyntax
{
    public ArgumentListSyntax()
    {
        OpenParenToken = null!;
        Arguments = null!;
        CloseParenToken = null!;
        Parent = null;
    }

    public ArgumentListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentListSyntax node, SyntaxNode? parent)
    {
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Arguments = Cloner.SeparatedListFrom<ArgumentSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentSyntax>(node.Arguments, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken OpenParenToken { get; init; }
    public SeparatedSyntaxList<ArgumentSyntax> Arguments { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
