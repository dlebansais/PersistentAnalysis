namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class MemberBindingExpressionSyntax : ExpressionSyntax
{
    public MemberBindingExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.MemberBindingExpressionSyntax node, SyntaxNode? parent)
    {
        OperatorToken = Cloner.ToToken(node.OperatorToken);
        Name = SimpleNameSyntax.From(node.Name, this);
        Parent = parent;
    }

    public SyntaxToken OperatorToken { get; }
    public SimpleNameSyntax Name { get; }
    public SyntaxNode? Parent { get; }
}
