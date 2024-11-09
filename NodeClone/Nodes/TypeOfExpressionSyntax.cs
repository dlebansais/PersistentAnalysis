namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class TypeOfExpressionSyntax : ExpressionSyntax
{
    public TypeOfExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.TypeOfExpressionSyntax node, SyntaxNode? parent)
    {
        Keyword = Cloner.ToToken(node.Keyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Type = TypeSyntax.From(node.Type, this);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken Keyword { get; }
    public SyntaxToken OpenParenToken { get; }
    public TypeSyntax Type { get; }
    public SyntaxToken CloseParenToken { get; }
    public SyntaxNode? Parent { get; }
}
