namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class DiscardDesignationSyntax : VariableDesignationSyntax
{
    public DiscardDesignationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.DiscardDesignationSyntax node, SyntaxNode? parent)
    {
        UnderscoreToken = Cloner.ToToken(node.UnderscoreToken);
        Parent = parent;
    }

    public SyntaxToken UnderscoreToken { get; }
    public SyntaxNode? Parent { get; }
}
