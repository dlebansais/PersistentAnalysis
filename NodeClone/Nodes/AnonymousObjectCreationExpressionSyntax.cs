namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class AnonymousObjectCreationExpressionSyntax : ExpressionSyntax
{
    public AnonymousObjectCreationExpressionSyntax()
    {
        NewKeyword = null!;
        OpenBraceToken = null!;
        Initializers = null!;
        CloseBraceToken = null!;
        Parent = null;
    }

    public AnonymousObjectCreationExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousObjectCreationExpressionSyntax node, SyntaxNode? parent)
    {
        NewKeyword = Cloner.ToToken(node.NewKeyword);
        OpenBraceToken = Cloner.ToToken(node.OpenBraceToken);
        Initializers = Cloner.SeparatedListFrom<AnonymousObjectMemberDeclaratorSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousObjectMemberDeclaratorSyntax>(node.Initializers, parent);
        CloseBraceToken = Cloner.ToToken(node.CloseBraceToken);
        Parent = parent;
    }

    public SyntaxToken NewKeyword { get; init; }
    public SyntaxToken OpenBraceToken { get; init; }
    public SeparatedSyntaxList<AnonymousObjectMemberDeclaratorSyntax> Initializers { get; init; }
    public SyntaxToken CloseBraceToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
