namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ExplicitInterfaceSpecifierSyntax : SyntaxNode
{
    public ExplicitInterfaceSpecifierSyntax()
    {
        Name = null!;
        DotToken = null!;
        Parent = null;
    }

    public ExplicitInterfaceSpecifierSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ExplicitInterfaceSpecifierSyntax node, SyntaxNode? parent)
    {
        Name = NameSyntax.From(node.Name, this);
        DotToken = Cloner.ToToken(node.DotToken);
        Parent = parent;
    }

    public NameSyntax Name { get; init; }
    public SyntaxToken DotToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Name.AppendTo(stringBuilder);
        DotToken.AppendTo(stringBuilder);
    }
}
