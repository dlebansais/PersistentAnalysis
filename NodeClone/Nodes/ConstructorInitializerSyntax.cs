namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ConstructorInitializerSyntax : SyntaxNode
{
    public ConstructorInitializerSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ConstructorInitializerSyntax node, SyntaxNode? parent)
    {
        ColonToken = Cloner.ToToken(node.ColonToken);
        ThisOrBaseKeyword = Cloner.ToToken(node.ThisOrBaseKeyword);
        ArgumentList = new ArgumentListSyntax(node.ArgumentList, this);
        Parent = parent;
    }

    public SyntaxToken ColonToken { get; }
    public SyntaxToken ThisOrBaseKeyword { get; }
    public ArgumentListSyntax ArgumentList { get; }
    public SyntaxNode? Parent { get; }
}
