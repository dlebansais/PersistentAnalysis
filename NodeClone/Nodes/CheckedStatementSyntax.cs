namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class CheckedStatementSyntax : StatementSyntax
{
    public CheckedStatementSyntax()
    {
        AttributeLists = null!;
        Keyword = null!;
        Block = null!;
        Parent = null;
    }

    public CheckedStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.CheckedStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        Keyword = Cloner.ToToken(node.Keyword);
        Block = new BlockSyntax(node.Block, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken Keyword { get; init; }
    public BlockSyntax Block { get; init; }
    public SyntaxNode? Parent { get; init; }
}
