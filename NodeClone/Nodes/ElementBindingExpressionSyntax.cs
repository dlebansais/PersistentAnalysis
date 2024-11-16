namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ElementBindingExpressionSyntax : ExpressionSyntax
{
    public ElementBindingExpressionSyntax()
    {
        ArgumentList = null!;
        Parent = null;
    }

    public ElementBindingExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ElementBindingExpressionSyntax node, SyntaxNode? parent)
    {
        ArgumentList = new BracketedArgumentListSyntax(node.ArgumentList, this);
        Parent = parent;
    }

    public BracketedArgumentListSyntax ArgumentList { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        ArgumentList.AppendTo(stringBuilder);
    }
}
