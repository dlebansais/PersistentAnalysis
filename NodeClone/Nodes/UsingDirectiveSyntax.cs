namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class UsingDirectiveSyntax : SyntaxNode
{
    public UsingDirectiveSyntax()
    {
        Name = null!;
        GlobalKeyword = null!;
        UsingKeyword = null!;
        StaticKeyword = null!;
        UnsafeKeyword = null!;
        Alias = null!;
        NamespaceOrType = null!;
        SemicolonToken = null!;
        Parent = null;
    }

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

    public NameSyntax? Name { get; init; }
    public SyntaxToken GlobalKeyword { get; init; }
    public SyntaxToken UsingKeyword { get; init; }
    public SyntaxToken StaticKeyword { get; init; }
    public SyntaxToken UnsafeKeyword { get; init; }
    public NameEqualsSyntax? Alias { get; init; }
    public TypeSyntax NamespaceOrType { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Name?.AppendTo(stringBuilder);
        GlobalKeyword.AppendTo(stringBuilder);
        UsingKeyword.AppendTo(stringBuilder);
        StaticKeyword.AppendTo(stringBuilder);
        UnsafeKeyword.AppendTo(stringBuilder);
        Alias?.AppendTo(stringBuilder);
        NamespaceOrType.AppendTo(stringBuilder);
        SemicolonToken.AppendTo(stringBuilder);
    }
}
