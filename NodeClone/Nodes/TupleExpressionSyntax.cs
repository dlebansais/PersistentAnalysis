namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class TupleExpressionSyntax : ExpressionSyntax
{
    public TupleExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.TupleExpressionSyntax node, SyntaxNode? parent)
    {
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        Arguments = Cloner.SeparatedListFrom<ArgumentSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentSyntax>(node.Arguments, parent);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken OpenParenToken { get; }
    public SeparatedSyntaxList<ArgumentSyntax> Arguments { get; }
    public SyntaxToken CloseParenToken { get; }
    public SyntaxNode? Parent { get; }
}
