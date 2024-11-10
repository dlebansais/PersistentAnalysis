namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class InitializerExpressionSyntax : ExpressionSyntax
{
    public InitializerExpressionSyntax()
    {
        OpenBraceToken = null!;
        Expressions = null!;
        CloseBraceToken = null!;
        Parent = null;
    }

    public InitializerExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.InitializerExpressionSyntax node, SyntaxNode? parent)
    {
        OpenBraceToken = Cloner.ToToken(node.OpenBraceToken);
        Expressions = Cloner.SeparatedListFrom<ExpressionSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax>(node.Expressions, parent);
        CloseBraceToken = Cloner.ToToken(node.CloseBraceToken);
        Parent = parent;
    }

    public SyntaxToken OpenBraceToken { get; init; }
    public SeparatedSyntaxList<ExpressionSyntax> Expressions { get; init; }
    public SyntaxToken CloseBraceToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
