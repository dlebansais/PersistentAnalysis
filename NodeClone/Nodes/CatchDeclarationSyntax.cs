namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class CatchDeclarationSyntax : SyntaxNode
{
    public CatchDeclarationSyntax()
    {
        OpenParenToken = null!;
        Type = null!;
        Identifier = null!;
        CloseParenToken = null!;
        Parent = null;
    }

    public CatchDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.CatchDeclarationSyntax node, SyntaxNode? parent)
    {
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Type = TypeSyntax.From(node.Type, this);
        Identifier = Cloner.ToToken(node.Identifier);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken OpenParenToken { get; init; }
    public TypeSyntax Type { get; init; }
    public SyntaxToken Identifier { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        OpenParenToken.AppendTo(stringBuilder);
        Type.AppendTo(stringBuilder);
        Identifier.AppendTo(stringBuilder);
        CloseParenToken.AppendTo(stringBuilder);
    }
}
