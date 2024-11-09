namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class BaseListSyntax : SyntaxNode
{
    public BaseListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.BaseListSyntax node, SyntaxNode? parent)
    {
        ColonToken = Cloner.ToToken(node.ColonToken);
        Types = Cloner.SeparatedListFrom<BaseTypeSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.BaseTypeSyntax>(node.Types, parent);
        Parent = parent;
    }

    public SyntaxToken ColonToken { get; }
    public SeparatedSyntaxList<BaseTypeSyntax> Types { get; }
    public SyntaxNode? Parent { get; }
}
