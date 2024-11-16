namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class SizeOfExpressionSyntax : ExpressionSyntax
{
    public SizeOfExpressionSyntax()
    {
        Keyword = null!;
        OpenParenToken = null!;
        Type = null!;
        CloseParenToken = null!;
        Parent = null;
    }

    public SizeOfExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.SizeOfExpressionSyntax node, SyntaxNode? parent)
    {
        Keyword = Cloner.ToToken(node.Keyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Type = TypeSyntax.From(node.Type, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken Keyword { get; init; }
    public SyntaxToken OpenParenToken { get; init; }
    public TypeSyntax Type { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Keyword.AppendTo(stringBuilder);
        OpenParenToken.AppendTo(stringBuilder);
        Type.AppendTo(stringBuilder);
        CloseParenToken.AppendTo(stringBuilder);
    }
}
