﻿namespace NodeClone;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ArgumentListSyntax : BaseArgumentListSyntax
{
    public ArgumentListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentListSyntax node, SyntaxNode? parent)
    {
        OpenParenToken = node.OpenParenToken;
        Arguments = Cloner.SeparatedListFrom<ArgumentSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentSyntax>(node.Arguments, parent);
        CloseParenToken = node.CloseParenToken;
        Parent = parent;
    }

    public SyntaxToken OpenParenToken { get; }
    public SeparatedSyntaxList<ArgumentSyntax> Arguments { get; }
    public SyntaxToken CloseParenToken { get; }
    public SyntaxNode? Parent { get; }

}
