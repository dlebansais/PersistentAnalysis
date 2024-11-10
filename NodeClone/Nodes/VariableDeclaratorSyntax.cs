namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class VariableDeclaratorSyntax : SyntaxNode
{
    public VariableDeclaratorSyntax()
    {
        Identifier = null!;
        ArgumentList = null!;
        Initializer = null!;
        Parent = null;
    }

    public VariableDeclaratorSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclaratorSyntax node, SyntaxNode? parent)
    {
        Identifier = Cloner.ToToken(node.Identifier);
        ArgumentList = node.ArgumentList is null ? null : new BracketedArgumentListSyntax(node.ArgumentList, this);
        Initializer = node.Initializer is null ? null : new EqualsValueClauseSyntax(node.Initializer, this);
        Parent = parent;
    }

    public SyntaxToken Identifier { get; init; }
    public BracketedArgumentListSyntax? ArgumentList { get; init; }
    public EqualsValueClauseSyntax? Initializer { get; init; }
    public SyntaxNode? Parent { get; init; }
}
