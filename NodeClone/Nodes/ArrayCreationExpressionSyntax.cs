namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ArrayCreationExpressionSyntax : ExpressionSyntax
{
    public ArrayCreationExpressionSyntax()
    {
        NewKeyword = null!;
        Type = null!;
        Initializer = null!;
        Parent = null;
    }

    public ArrayCreationExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ArrayCreationExpressionSyntax node, SyntaxNode? parent)
    {
        NewKeyword = Cloner.ToToken(node.NewKeyword);
        Type = new ArrayTypeSyntax(node.Type, this);
        Initializer = node.Initializer is null ? null : new InitializerExpressionSyntax(node.Initializer, this);
        Parent = parent;
    }

    public SyntaxToken NewKeyword { get; init; }
    public ArrayTypeSyntax Type { get; init; }
    public InitializerExpressionSyntax? Initializer { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        NewKeyword.AppendTo(stringBuilder);
        Type.AppendTo(stringBuilder);
        Initializer?.AppendTo(stringBuilder);
    }
}
