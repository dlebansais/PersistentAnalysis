namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class LocalDeclarationStatementSyntax : StatementSyntax
{
    public LocalDeclarationStatementSyntax()
    {
        AttributeLists = null!;
        AwaitKeyword = null!;
        UsingKeyword = null!;
        Declaration = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public LocalDeclarationStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        AwaitKeyword = Cloner.ToToken(node.AwaitKeyword);
        UsingKeyword = Cloner.ToToken(node.UsingKeyword);
        Declaration = new VariableDeclarationSyntax(node.Declaration, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken AwaitKeyword { get; init; }
    public SyntaxToken UsingKeyword { get; init; }
    public VariableDeclarationSyntax Declaration { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
