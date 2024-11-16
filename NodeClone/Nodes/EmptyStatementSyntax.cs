namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class EmptyStatementSyntax : StatementSyntax
{
    public EmptyStatementSyntax()
    {
        AttributeLists = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public EmptyStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.EmptyStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        AttributeLists.AppendTo(stringBuilder);
        SemicolonToken.AppendTo(stringBuilder);
    }
}
