namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class InterpolatedStringExpressionSyntax : ExpressionSyntax
{
    public InterpolatedStringExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringExpressionSyntax node, SyntaxNode? parent)
    {
        StringStartToken = Cloner.ToToken(node.StringStartToken);
        Contents = Cloner.ListFrom<InterpolatedStringContentSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringContentSyntax>(node.Contents, parent);
        StringEndToken = Cloner.ToToken(node.StringEndToken);
        Parent = parent;
    }

    public SyntaxToken StringStartToken { get; }
    public SyntaxList<InterpolatedStringContentSyntax> Contents { get; }
    public SyntaxToken StringEndToken { get; }
    public SyntaxNode? Parent { get; }
}
