namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ImplicitObjectCreationExpressionSyntax : BaseObjectCreationExpressionSyntax
{
    public ImplicitObjectCreationExpressionSyntax()
    {
        NewKeyword = null!;
        ArgumentList = null!;
        Initializer = null!;
        Parent = null;
    }

    public ImplicitObjectCreationExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitObjectCreationExpressionSyntax node, SyntaxNode? parent)
    {
        NewKeyword = Cloner.ToToken(node.NewKeyword);
        ArgumentList = new ArgumentListSyntax(node.ArgumentList, this);
        Initializer = node.Initializer is null ? null : new InitializerExpressionSyntax(node.Initializer, this);
        Parent = parent;
    }

    public SyntaxToken NewKeyword { get; init; }
    public ArgumentListSyntax ArgumentList { get; init; }
    public InitializerExpressionSyntax? Initializer { get; init; }
    public SyntaxNode? Parent { get; init; }
}
