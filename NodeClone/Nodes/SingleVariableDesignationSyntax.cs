namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class SingleVariableDesignationSyntax : VariableDesignationSyntax
{
    public SingleVariableDesignationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.SingleVariableDesignationSyntax node, SyntaxNode? parent)
    {
        Identifier = Cloner.ToToken(node.Identifier);
        Parent = parent;
    }

    public SyntaxToken Identifier { get; }
    public SyntaxNode? Parent { get; }
}
