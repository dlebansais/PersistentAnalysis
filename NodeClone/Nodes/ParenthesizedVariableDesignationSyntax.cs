namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ParenthesizedVariableDesignationSyntax : VariableDesignationSyntax
{
    public ParenthesizedVariableDesignationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedVariableDesignationSyntax node, SyntaxNode? parent)
    {
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Variables = Cloner.SeparatedListFrom<VariableDesignationSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.VariableDesignationSyntax>(node.Variables, parent);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken OpenParenToken { get; }
    public SeparatedSyntaxList<VariableDesignationSyntax> Variables { get; }
    public SyntaxToken CloseParenToken { get; }
    public SyntaxNode? Parent { get; }
}
