namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class FinallyClauseSyntax : SyntaxNode
{
    public FinallyClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.FinallyClauseSyntax node, SyntaxNode? parent)
    {
        FinallyKeyword = Cloner.ToToken(node.FinallyKeyword);
        Block = new BlockSyntax(node.Block, this);
        Parent = parent;
    }

    public SyntaxToken FinallyKeyword { get; }
    public BlockSyntax Block { get; }
    public SyntaxNode? Parent { get; }
}
