namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class BaseListSyntax : SyntaxNode
{
    public BaseListSyntax()
    {
        ColonToken = null!;
        Types = null!;
        Parent = null;
    }

    public BaseListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.BaseListSyntax node, SyntaxNode? parent)
    {
        ColonToken = Cloner.ToToken(node.ColonToken);
        Types = Cloner.SeparatedListFrom<BaseTypeSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.BaseTypeSyntax>(node.Types, this);
        Parent = parent;
    }

    public SyntaxToken ColonToken { get; init; }
    public SeparatedSyntaxList<BaseTypeSyntax> Types { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        ColonToken.AppendTo(stringBuilder);
        Types.AppendTo(stringBuilder);
    }
}
