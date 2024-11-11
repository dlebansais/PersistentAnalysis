namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class UnsafeStatementSyntax : StatementSyntax
{
    public UnsafeStatementSyntax()
    {
        AttributeLists = null!;
        UnsafeKeyword = null!;
        Block = null!;
        Parent = null;
    }

    public UnsafeStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.UnsafeStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        UnsafeKeyword = Cloner.ToToken(node.UnsafeKeyword);
        Block = new BlockSyntax(node.Block, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken UnsafeKeyword { get; init; }
    public BlockSyntax Block { get; init; }
    public SyntaxNode? Parent { get; init; }
}
