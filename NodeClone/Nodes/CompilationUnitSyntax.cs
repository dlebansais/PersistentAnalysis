namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class CompilationUnitSyntax : SyntaxNode
{
    public CompilationUnitSyntax()
    {
        Externs = null!;
        Usings = null!;
        AttributeLists = null!;
        Members = null!;
        EndOfFileToken = null!;
        Parent = null;
    }

    public CompilationUnitSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.CompilationUnitSyntax node)
    {
        Externs = Cloner.ListFrom<ExternAliasDirectiveSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.ExternAliasDirectiveSyntax>(node.Externs, this);
        Usings = Cloner.ListFrom<UsingDirectiveSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax>(node.Usings, this);
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        Members = Cloner.ListFrom<MemberDeclarationSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax>(node.Members, this);
        EndOfFileToken = Cloner.ToToken(node.EndOfFileToken);
        Parent = null;
    }

    public SyntaxList<ExternAliasDirectiveSyntax> Externs { get; init; }
    public SyntaxList<UsingDirectiveSyntax> Usings { get; init; }
    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxList<MemberDeclarationSyntax> Members { get; init; }
    public SyntaxToken EndOfFileToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
