namespace NodeClone;

using System.Text;
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
        Initializers = Cloner.SeparatedListFrom<AnonymousObjectMemberDeclaratorSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousObjectMemberDeclaratorSyntax>(node.Initializers, this);
        CloseBraceToken = Cloner.ToToken(node.CloseBraceToken);
        Parent = parent;
    }

    public SyntaxToken NewKeyword { get; init; }
    public SyntaxToken OpenBraceToken { get; init; }
    public SeparatedSyntaxList<AnonymousObjectMemberDeclaratorSyntax> Initializers { get; init; }
    public SyntaxToken CloseBraceToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        NewKeyword.AppendTo(stringBuilder);
        OpenBraceToken.AppendTo(stringBuilder);
        Initializers.AppendTo(stringBuilder);
        CloseBraceToken.AppendTo(stringBuilder);
    }
}
