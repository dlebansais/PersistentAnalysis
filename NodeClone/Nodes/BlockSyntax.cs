namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class BlockSyntax : StatementSyntax
{
    public BlockSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.BlockSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        OpenBraceToken = Cloner.ToToken(node.OpenBraceToken);
        Statements = Cloner.ListFrom<StatementSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax>(node.Statements, parent);
        CloseBraceToken = Cloner.ToToken(node.CloseBraceToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; }
    public SyntaxToken OpenBraceToken { get; }
    public SyntaxList<StatementSyntax> Statements { get; }
    public SyntaxToken CloseBraceToken { get; }
    public SyntaxNode? Parent { get; }
}
