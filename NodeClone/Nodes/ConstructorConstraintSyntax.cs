namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ConstructorConstraintSyntax : TypeParameterConstraintSyntax
{
    public ConstructorConstraintSyntax()
    {
        NewKeyword = null!;
        OpenParenToken = null!;
        CloseParenToken = null!;
        Parent = null;
    }

    public ConstructorConstraintSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ConstructorConstraintSyntax node, SyntaxNode? parent)
    {
        NewKeyword = Cloner.ToToken(node.NewKeyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken NewKeyword { get; init; }
    public SyntaxToken OpenParenToken { get; init; }
    public SyntaxToken CloseParenToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        NewKeyword.AppendTo(stringBuilder);
        OpenParenToken.AppendTo(stringBuilder);
        CloseParenToken.AppendTo(stringBuilder);
    }
}
