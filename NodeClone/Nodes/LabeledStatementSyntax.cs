namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class LabeledStatementSyntax : StatementSyntax
{
    public LabeledStatementSyntax()
    {
        AttributeLists = null!;
        Identifier = null!;
        ColonToken = null!;
        Statement = null!;
        Parent = null;
    }

    public LabeledStatementSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.LabeledStatementSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        Identifier = Cloner.ToToken(node.Identifier);
        ColonToken = Cloner.ToToken(node.ColonToken);
        Statement = StatementSyntax.From(node.Statement, this);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxToken Identifier { get; init; }
    public SyntaxToken ColonToken { get; init; }
    public StatementSyntax Statement { get; init; }
    public SyntaxNode? Parent { get; init; }
}
