namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class UsingDirectiveSyntax : SyntaxNode
{
    public UsingDirectiveSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax node, SyntaxNode? parent)
    {
        Name = node.Name is null ? null : NameSyntax.From(node.Name, this);
        GlobalKeyword = Cloner.ToToken(node.GlobalKeyword);
        UsingKeyword = Cloner.ToToken(node.UsingKeyword);
        StaticKeyword = Cloner.ToToken(node.StaticKeyword);
        UnsafeKeyword = Cloner.ToToken(node.UnsafeKeyword);
        Alias = node.Alias is null ? null : new NameEqualsSyntax(node.Alias, this);
        NamespaceOrType = TypeSyntax.From(node.NamespaceOrType, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public NameSyntax? Name { get; }
    public SyntaxToken GlobalKeyword { get; }
    public SyntaxToken UsingKeyword { get; }
    public SyntaxToken StaticKeyword { get; }
    public SyntaxToken UnsafeKeyword { get; }
    public NameEqualsSyntax? Alias { get; }
    public TypeSyntax NamespaceOrType { get; }
    public SyntaxToken SemicolonToken { get; }
    public SyntaxNode? Parent { get; }
}
