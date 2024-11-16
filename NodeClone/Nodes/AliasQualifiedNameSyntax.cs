namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class AliasQualifiedNameSyntax : NameSyntax
{
    public AliasQualifiedNameSyntax()
    {
        Alias = null!;
        ColonColonToken = null!;
        Name = null!;
        Parent = null;
    }

    public AliasQualifiedNameSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.AliasQualifiedNameSyntax node, SyntaxNode? parent)
    {
        Alias = new IdentifierNameSyntax(node.Alias, this);
        ColonColonToken = Cloner.ToToken(node.ColonColonToken);
        Name = SimpleNameSyntax.From(node.Name, this);
        Parent = parent;
    }

    public IdentifierNameSyntax Alias { get; init; }
    public SyntaxToken ColonColonToken { get; init; }
    public SimpleNameSyntax Name { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        Alias.AppendTo(stringBuilder);
        ColonColonToken.AppendTo(stringBuilder);
        Name.AppendTo(stringBuilder);
    }
}
