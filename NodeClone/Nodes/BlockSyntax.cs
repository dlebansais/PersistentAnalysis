namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class BlockSyntax : StatementSyntax
{
    public BlockSyntax()
    {
        AttributeLists = null!;
        OpenBraceToken = null!;
        Statements = null!;
        CloseBraceToken = null!;
        Parent = null;
    }

    public BlockSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.BlockSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        OpenBraceToken = Cloner.ToToken(node.OpenBraceToken);
        Statements = Cloner.ListFrom<StatementSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax>(node.Statements, this);
        CloseBraceToken = Cloner.ToToken(node.CloseBraceToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken OpenBraceToken { get; init; }
    public SyntaxList<StatementSyntax> Statements { get; init; }
    public SyntaxToken CloseBraceToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        AttributeLists.AppendTo(stringBuilder);
        OpenBraceToken.AppendTo(stringBuilder);
        Statements.AppendTo(stringBuilder);
        CloseBraceToken.AppendTo(stringBuilder);
    }
}
