namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class FinallyClauseSyntax : SyntaxNode
{
    public FinallyClauseSyntax()
    {
        FinallyKeyword = null!;
        Block = null!;
        Parent = null;
    }

    public FinallyClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.FinallyClauseSyntax node, SyntaxNode? parent)
    {
        FinallyKeyword = Cloner.ToToken(node.FinallyKeyword);
        Block = new BlockSyntax(node.Block, this);
        Parent = parent;
    }

    public SyntaxToken FinallyKeyword { get; init; }
    public BlockSyntax Block { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        FinallyKeyword.AppendTo(stringBuilder);
        Block.AppendTo(stringBuilder);
    }
}
