namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class LocalDeclarationStatementSyntax : StatementSyntax
{
    public LocalDeclarationStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        AwaitKeyword = Cloner.ToToken(node.AwaitKeyword);
        UsingKeyword = Cloner.ToToken(node.UsingKeyword);
        Declaration = new VariableDeclarationSyntax(node.Declaration, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; }
    public SyntaxToken AwaitKeyword { get; }
    public SyntaxToken UsingKeyword { get; }
    public VariableDeclarationSyntax Declaration { get; }
    public SyntaxToken SemicolonToken { get; }
    public SyntaxNode? Parent { get; }
}
