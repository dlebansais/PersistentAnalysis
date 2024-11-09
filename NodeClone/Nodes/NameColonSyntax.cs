namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class NameColonSyntax : BaseExpressionColonSyntax
{
    public NameColonSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.NameColonSyntax node, SyntaxNode? parent)
    {
        Expression = ExpressionSyntax.From(node.Expression, this);
        Name = new IdentifierNameSyntax(node.Name, this);
        ColonToken = Cloner.ToToken(node.ColonToken);
        Parent = parent;
    }

    public ExpressionSyntax Expression { get; }
    public IdentifierNameSyntax Name { get; }
    public SyntaxToken ColonToken { get; }
    public SyntaxNode? Parent { get; }
}
