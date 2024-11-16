namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class TryStatementSyntax : StatementSyntax
{
    public TryStatementSyntax()
    {
        AttributeLists = null!;
        TryKeyword = null!;
        Block = null!;
        Catches = null!;
        Finally = null!;
        Parent = null;
    }

    public TryStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.TryStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        TryKeyword = Cloner.ToToken(node.TryKeyword);
        Block = new BlockSyntax(node.Block, this);
        Catches = Cloner.ListFrom<CatchClauseSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.CatchClauseSyntax>(node.Catches, this);
        Finally = node.Finally is null ? null : new FinallyClauseSyntax(node.Finally, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken TryKeyword { get; init; }
    public BlockSyntax Block { get; init; }
    public SyntaxList<CatchClauseSyntax> Catches { get; init; }
    public FinallyClauseSyntax? Finally { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        AttributeLists.AppendTo(stringBuilder);
        TryKeyword.AppendTo(stringBuilder);
        Block.AppendTo(stringBuilder);
        Catches.AppendTo(stringBuilder);
        Finally?.AppendTo(stringBuilder);
    }
}
