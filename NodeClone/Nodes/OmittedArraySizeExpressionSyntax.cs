namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class OmittedArraySizeExpressionSyntax : ExpressionSyntax
{
    public OmittedArraySizeExpressionSyntax()
    {
        OmittedArraySizeExpressionToken = null!;
        Parent = null;
    }

    public OmittedArraySizeExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.OmittedArraySizeExpressionSyntax node, SyntaxNode? parent)
    {
        OmittedArraySizeExpressionToken = Cloner.ToToken(node.OmittedArraySizeExpressionToken);
        Parent = parent;
    }

    public SyntaxToken OmittedArraySizeExpressionToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        OmittedArraySizeExpressionToken.AppendTo(stringBuilder);
    }
}
