namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ConstructorInitializerSyntax : SyntaxNode
{
    public ConstructorInitializerSyntax()
    {
        ColonToken = null!;
        ThisOrBaseKeyword = null!;
        ArgumentList = null!;
        Parent = null;
    }

    public ConstructorInitializerSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ConstructorInitializerSyntax node, SyntaxNode? parent)
    {
        ColonToken = Cloner.ToToken(node.ColonToken);
        ThisOrBaseKeyword = Cloner.ToToken(node.ThisOrBaseKeyword);
        ArgumentList = new ArgumentListSyntax(node.ArgumentList, this);
        Parent = parent;
    }

    public SyntaxToken ColonToken { get; init; }
    public SyntaxToken ThisOrBaseKeyword { get; init; }
    public ArgumentListSyntax ArgumentList { get; init; }
    public SyntaxNode? Parent { get; init; }
}
