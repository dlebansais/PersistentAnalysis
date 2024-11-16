namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ObjectCreationExpressionSyntax : BaseObjectCreationExpressionSyntax
{
    public ObjectCreationExpressionSyntax()
    {
        NewKeyword = null!;
        Type = null!;
        ArgumentList = null!;
        Initializer = null!;
        Parent = null;
    }

    public ObjectCreationExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ObjectCreationExpressionSyntax node, SyntaxNode? parent)
    {
        NewKeyword = Cloner.ToToken(node.NewKeyword);
        Type = TypeSyntax.From(node.Type, this);
        ArgumentList = node.ArgumentList is null ? null : new ArgumentListSyntax(node.ArgumentList, this);
        Initializer = node.Initializer is null ? null : new InitializerExpressionSyntax(node.Initializer, this);
        Parent = parent;
    }

    public SyntaxToken NewKeyword { get; init; }
    public TypeSyntax Type { get; init; }
    public ArgumentListSyntax? ArgumentList { get; init; }
    public InitializerExpressionSyntax? Initializer { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        NewKeyword.AppendTo(stringBuilder);
        Type.AppendTo(stringBuilder);
        ArgumentList?.AppendTo(stringBuilder);
        Initializer?.AppendTo(stringBuilder);
    }
}
