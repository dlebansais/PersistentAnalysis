﻿namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ParenthesizedVariableDesignationSyntax : VariableDesignationSyntax
{
    public ParenthesizedVariableDesignationSyntax()
    {
        OpenParenToken = null!;
        Variables = null!;
        CloseParenToken = null!;
        Parent = null;
    }

    public ParenthesizedVariableDesignationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedVariableDesignationSyntax node, SyntaxNode? parent)
    {
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Variables = Cloner.SeparatedListFrom<VariableDesignationSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.VariableDesignationSyntax>(node.Variables, parent);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken OpenParenToken { get; init; }
    public SeparatedSyntaxList<VariableDesignationSyntax> Variables { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
