namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class CatchClauseSyntax : SyntaxNode
{
    public CatchClauseSyntax()
    {
        CatchKeyword = null!;
        Declaration = null!;
        Filter = null!;
        Block = null!;
        Parent = null;
    }

    public CatchClauseSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.CatchClauseSyntax node, SyntaxNode? parent)
    {
        CatchKeyword = Cloner.ToToken(node.CatchKeyword);
        Declaration = node.Declaration is null ? null : new CatchDeclarationSyntax(node.Declaration, this);
        Filter = node.Filter is null ? null : new CatchFilterClauseSyntax(node.Filter, this);
        Block = new BlockSyntax(node.Block, this);
        Parent = parent;
    }

    public SyntaxToken CatchKeyword { get; init; }
    public CatchDeclarationSyntax? Declaration { get; init; }
    public CatchFilterClauseSyntax? Filter { get; init; }
    public BlockSyntax Block { get; init; }
    public SyntaxNode? Parent { get; init; }
}
