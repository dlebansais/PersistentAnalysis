namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class DeclarationPatternSyntax : PatternSyntax
{
    public DeclarationPatternSyntax()
    {
        Type = null!;
        Designation = null!;
        Parent = null;
    }

    public DeclarationPatternSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.DeclarationPatternSyntax node, SyntaxNode? parent)
    {
        Type = TypeSyntax.From(node.Type, this);
        Designation = VariableDesignationSyntax.From(node.Designation, this);
        Parent = parent;
    }

    public TypeSyntax Type { get; init; }
    public VariableDesignationSyntax Designation { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Type.AppendTo(stringBuilder);
        Designation.AppendTo(stringBuilder);
    }
}
