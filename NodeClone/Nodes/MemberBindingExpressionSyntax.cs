namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class MemberBindingExpressionSyntax : ExpressionSyntax
{
    public MemberBindingExpressionSyntax()
    {
        OperatorToken = null!;
        Name = null!;
        Parent = null;
    }

    public MemberBindingExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.MemberBindingExpressionSyntax node, SyntaxNode? parent)
    {
        OperatorToken = Cloner.ToToken(node.OperatorToken);
        Name = SimpleNameSyntax.From(node.Name, this);
        Parent = parent;
    }

    public SyntaxToken OperatorToken { get; init; }
    public SimpleNameSyntax Name { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        OperatorToken.AppendTo(stringBuilder);
        Name.AppendTo(stringBuilder);
    }
}
