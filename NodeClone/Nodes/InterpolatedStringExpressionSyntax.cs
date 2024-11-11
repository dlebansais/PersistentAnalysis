namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class InterpolatedStringExpressionSyntax : ExpressionSyntax
{
    public InterpolatedStringExpressionSyntax()
    {
        StringStartToken = null!;
        Contents = null!;
        StringEndToken = null!;
        Parent = null;
    }

    public InterpolatedStringExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringExpressionSyntax node, SyntaxNode? parent)
    {
        StringStartToken = Cloner.ToToken(node.StringStartToken);
        Contents = Cloner.ListFrom<InterpolatedStringContentSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringContentSyntax>(node.Contents, this);
        StringEndToken = Cloner.ToToken(node.StringEndToken);
        Parent = parent;
    }

    public SyntaxToken StringStartToken { get; init; }
    public SyntaxList<InterpolatedStringContentSyntax> Contents { get; init; }
    public SyntaxToken StringEndToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
