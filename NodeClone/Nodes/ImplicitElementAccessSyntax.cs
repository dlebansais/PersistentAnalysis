namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ImplicitElementAccessSyntax : ExpressionSyntax
{
    public ImplicitElementAccessSyntax()
    {
        ArgumentList = null!;
        Parent = null;
    }

    public ImplicitElementAccessSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitElementAccessSyntax node, SyntaxNode? parent)
    {
        ArgumentList = new BracketedArgumentListSyntax(node.ArgumentList, this);
        Parent = parent;
    }

    public BracketedArgumentListSyntax ArgumentList { get; init; }
    public SyntaxNode? Parent { get; init; }
}
