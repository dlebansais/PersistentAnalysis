namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class SwitchSectionSyntax : SyntaxNode
{
    public SwitchSectionSyntax()
    {
        Labels = null!;
        Statements = null!;
        Parent = null;
    }

    public SwitchSectionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.SwitchSectionSyntax node, SyntaxNode? parent)
    {
        Labels = Cloner.ListFrom<SwitchLabelSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.SwitchLabelSyntax>(node.Labels, this);
        Statements = Cloner.ListFrom<StatementSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax>(node.Statements, this);
        Parent = parent;
    }

    public SyntaxList<SwitchLabelSyntax> Labels { get; init; }
    public SyntaxList<StatementSyntax> Statements { get; init; }
    public SyntaxNode? Parent { get; init; }
}
