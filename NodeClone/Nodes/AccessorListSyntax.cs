namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class AccessorListSyntax : SyntaxNode
{
    public AccessorListSyntax()
    {
        OpenBraceToken = null!;
        Accessors = null!;
        CloseBraceToken = null!;
        Parent = null;
    }

    public AccessorListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.AccessorListSyntax node, SyntaxNode? parent)
    {
        OpenBraceToken = Cloner.ToToken(node.OpenBraceToken);
        Accessors = Cloner.ListFrom<AccessorDeclarationSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AccessorDeclarationSyntax>(node.Accessors, this);
        CloseBraceToken = Cloner.ToToken(node.CloseBraceToken);
        Parent = parent;
    }

    public SyntaxToken OpenBraceToken { get; init; }
    public SyntaxList<AccessorDeclarationSyntax> Accessors { get; init; }
    public SyntaxToken CloseBraceToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        OpenBraceToken.AppendTo(stringBuilder);
        Accessors.AppendTo(stringBuilder);
        CloseBraceToken.AppendTo(stringBuilder);
    }
}
