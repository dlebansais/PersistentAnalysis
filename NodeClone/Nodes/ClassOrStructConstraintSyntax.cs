namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ClassOrStructConstraintSyntax : TypeParameterConstraintSyntax
{
    public ClassOrStructConstraintSyntax()
    {
        ClassOrStructKeyword = null!;
        QuestionToken = null!;
        Parent = null;
    }

    public ClassOrStructConstraintSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ClassOrStructConstraintSyntax node, SyntaxNode? parent)
    {
        ClassOrStructKeyword = Cloner.ToToken(node.ClassOrStructKeyword);
        QuestionToken = Cloner.ToToken(node.QuestionToken);
        Parent = parent;
    }

    public SyntaxToken ClassOrStructKeyword { get; init; }
    public SyntaxToken QuestionToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        ClassOrStructKeyword.AppendTo(stringBuilder);
        QuestionToken.AppendTo(stringBuilder);
    }
}
