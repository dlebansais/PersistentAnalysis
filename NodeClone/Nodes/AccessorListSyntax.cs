namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class AccessorListSyntax : SyntaxNode
{
    public AccessorListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.AccessorListSyntax node, SyntaxNode? parent)
    {
        OpenBraceToken = Cloner.ToToken(node.OpenBraceToken);
        Accessors = Cloner.ListFrom<AccessorDeclarationSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AccessorDeclarationSyntax>(node.Accessors, parent);
        CloseBraceToken = Cloner.ToToken(node.CloseBraceToken);
        Parent = parent;
    }

    public SyntaxToken OpenBraceToken { get; }
    public SyntaxList<AccessorDeclarationSyntax> Accessors { get; }
    public SyntaxToken CloseBraceToken { get; }
    public SyntaxNode? Parent { get; }
}
