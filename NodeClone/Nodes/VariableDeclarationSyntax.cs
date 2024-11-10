namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class VariableDeclarationSyntax : SyntaxNode
{
    public VariableDeclarationSyntax()
    {
        Type = null!;
        Variables = null!;
        Parent = null;
    }

    public VariableDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclarationSyntax node, SyntaxNode? parent)
    {
        Type = TypeSyntax.From(node.Type, this);
        Variables = Cloner.SeparatedListFrom<VariableDeclaratorSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclaratorSyntax>(node.Variables, parent);
        Parent = parent;
    }

    public TypeSyntax Type { get; init; }
    public SeparatedSyntaxList<VariableDeclaratorSyntax> Variables { get; init; }
    public SyntaxNode? Parent { get; init; }
}
