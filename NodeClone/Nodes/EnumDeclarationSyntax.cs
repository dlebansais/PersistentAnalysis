namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class EnumDeclarationSyntax : BaseTypeDeclarationSyntax
{
    public EnumDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, parent);
        EnumKeyword = Cloner.ToToken(node.EnumKeyword);
        Identifier = Cloner.ToToken(node.Identifier);
        BaseList = node.BaseList is null ? null : new BaseListSyntax(node.BaseList, this);
        OpenBraceToken = Cloner.ToToken(node.OpenBraceToken);
        Members = Cloner.SeparatedListFrom<EnumMemberDeclarationSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax>(node.Members, parent);
        CloseBraceToken = Cloner.ToToken(node.CloseBraceToken);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; }
    public SyntaxToken EnumKeyword { get; }
    public SyntaxToken Identifier { get; }
    public BaseListSyntax? BaseList { get; }
    public SyntaxToken OpenBraceToken { get; }
    public SeparatedSyntaxList<EnumMemberDeclarationSyntax> Members { get; }
    public SyntaxToken CloseBraceToken { get; }
    public SyntaxToken SemicolonToken { get; }
    public SyntaxNode? Parent { get; }
}
