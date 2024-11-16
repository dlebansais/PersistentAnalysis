namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ExternAliasDirectiveSyntax : SyntaxNode
{
    public ExternAliasDirectiveSyntax()
    {
        ExternKeyword = null!;
        AliasKeyword = null!;
        Identifier = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public ExternAliasDirectiveSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ExternAliasDirectiveSyntax node, SyntaxNode? parent)
    {
        ExternKeyword = Cloner.ToToken(node.ExternKeyword);
        AliasKeyword = Cloner.ToToken(node.AliasKeyword);
        Identifier = Cloner.ToToken(node.Identifier);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxToken ExternKeyword { get; init; }
    public SyntaxToken AliasKeyword { get; init; }
    public SyntaxToken Identifier { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        ExternKeyword.AppendTo(stringBuilder);
        AliasKeyword.AppendTo(stringBuilder);
        Identifier.AppendTo(stringBuilder);
        SemicolonToken.AppendTo(stringBuilder);
    }
}
