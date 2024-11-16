namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class AttributeSyntax : SyntaxNode
{
    public AttributeSyntax()
    {
        Name = null!;
        ArgumentList = null!;
        Parent = null;
    }

    public AttributeSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.AttributeSyntax node, SyntaxNode? parent)
    {
        Name = NameSyntax.From(node.Name, this);
        ArgumentList = node.ArgumentList is null ? null : new AttributeArgumentListSyntax(node.ArgumentList, this);
        Parent = parent;
    }

    public NameSyntax Name { get; init; }
    public AttributeArgumentListSyntax? ArgumentList { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Name.AppendTo(stringBuilder);
        ArgumentList?.AppendTo(stringBuilder);
    }
}
