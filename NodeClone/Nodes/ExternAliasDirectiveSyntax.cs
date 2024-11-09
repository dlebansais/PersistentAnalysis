namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ExternAliasDirectiveSyntax : SyntaxNode
{
    public ExternAliasDirectiveSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ExternAliasDirectiveSyntax node, SyntaxNode? parent)
    {
        ExternKeyword = Cloner.ToToken(node.ExternKeyword);
        AliasKeyword = Cloner.ToToken(node.AliasKeyword);
        Identifier = Cloner.ToToken(node.Identifier);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxToken ExternKeyword { get; }
    public SyntaxToken AliasKeyword { get; }
    public SyntaxToken Identifier { get; }
    public SyntaxToken SemicolonToken { get; }
    public SyntaxNode? Parent { get; }
}
