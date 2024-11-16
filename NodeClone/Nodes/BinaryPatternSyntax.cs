namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class BinaryPatternSyntax : PatternSyntax
{
    public BinaryPatternSyntax()
    {
        Left = null!;
        OperatorToken = null!;
        Right = null!;
        Parent = null;
    }

    public BinaryPatternSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.BinaryPatternSyntax node, SyntaxNode? parent)
    {
        Left = PatternSyntax.From(node.Left, this);
        OperatorToken = Cloner.ToToken(node.OperatorToken);
        Right = PatternSyntax.From(node.Right, this);
        Parent = parent;
    }

    public PatternSyntax Left { get; init; }
    public SyntaxToken OperatorToken { get; init; }
    public PatternSyntax Right { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Left.AppendTo(stringBuilder);
        OperatorToken.AppendTo(stringBuilder);
        Right.AppendTo(stringBuilder);
    }
}
