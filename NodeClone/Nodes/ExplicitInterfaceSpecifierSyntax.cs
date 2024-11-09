namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ExplicitInterfaceSpecifierSyntax : SyntaxNode
{
    public ExplicitInterfaceSpecifierSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ExplicitInterfaceSpecifierSyntax node, SyntaxNode? parent)
    {
        Name = NameSyntax.From(node.Name, this);
        DotToken = Cloner.ToToken(node.DotToken);
        Parent = parent;
    }

    public NameSyntax Name { get; }
    public SyntaxToken DotToken { get; }
    public SyntaxNode? Parent { get; }
}
