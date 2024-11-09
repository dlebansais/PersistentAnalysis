namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ConstructorConstraintSyntax : TypeParameterConstraintSyntax
{
    public ConstructorConstraintSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ConstructorConstraintSyntax node, SyntaxNode? parent)
    {
        NewKeyword = Cloner.ToToken(node.NewKeyword);
        OpenParenToken = Cloner.ToToken(node.OpenParenToken);
        CloseParenToken = Cloner.ToToken(node.CloseParenToken);
        Parent = parent;
    }

    public SyntaxToken NewKeyword { get; }
    public SyntaxToken OpenParenToken { get; }
    public SyntaxToken CloseParenToken { get; }
    public SyntaxNode? Parent { get; }
}
