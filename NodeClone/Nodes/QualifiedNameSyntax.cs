namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class QualifiedNameSyntax : NameSyntax
{
    public QualifiedNameSyntax()
    {
        Left = null!;
        DotToken = null!;
        Right = null!;
        Parent = null;
    }

    public QualifiedNameSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.QualifiedNameSyntax node, SyntaxNode? parent)
    {
        Left = NameSyntax.From(node.Left, this);
        DotToken = Cloner.ToToken(node.DotToken);
        Right = SimpleNameSyntax.From(node.Right, this);
        Parent = parent;
    }

    public NameSyntax Left { get; init; }
    public SyntaxToken DotToken { get; init; }
    public SimpleNameSyntax Right { get; init; }
    public SyntaxNode? Parent { get; init; }
}
