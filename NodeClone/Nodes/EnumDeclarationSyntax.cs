namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class EnumDeclarationSyntax : BaseTypeDeclarationSyntax
{
    public EnumDeclarationSyntax()
    {
        AttributeLists = null!;
        Modifiers = null!;
        EnumKeyword = null!;
        Identifier = null!;
        BaseList = null!;
        OpenBraceToken = null!;
        Members = null!;
        CloseBraceToken = null!;
        SemicolonToken = null!;
        Parent = null;
    }

    public EnumDeclarationSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax node, SyntaxNode? parent)
    {
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        Modifiers = Cloner.ToTokenList(node.Modifiers);
        EnumKeyword = Cloner.ToToken(node.EnumKeyword);
        Identifier = Cloner.ToToken(node.Identifier);
        BaseList = node.BaseList is null ? null : new BaseListSyntax(node.BaseList, this);
        OpenBraceToken = Cloner.ToToken(node.OpenBraceToken);
        Members = Cloner.SeparatedListFrom<EnumMemberDeclarationSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax>(node.Members, this);
        CloseBraceToken = Cloner.ToToken(node.CloseBraceToken);
        SemicolonToken = Cloner.ToToken(node.SemicolonToken);
        Parent = parent;
    }

    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public SyntaxTokenList Modifiers { get; init; }
    public SyntaxToken EnumKeyword { get; init; }
    public SyntaxToken Identifier { get; init; }
    public BaseListSyntax? BaseList { get; init; }
    public SyntaxToken OpenBraceToken { get; init; }
    public SeparatedSyntaxList<EnumMemberDeclarationSyntax> Members { get; init; }
    public SyntaxToken CloseBraceToken { get; init; }
    public SyntaxToken SemicolonToken { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        AttributeLists.AppendTo(stringBuilder);
        Modifiers.AppendTo(stringBuilder);
        EnumKeyword.AppendTo(stringBuilder);
        Identifier.AppendTo(stringBuilder);
        BaseList?.AppendTo(stringBuilder);
        OpenBraceToken.AppendTo(stringBuilder);
        Members.AppendTo(stringBuilder);
        CloseBraceToken.AppendTo(stringBuilder);
        SemicolonToken.AppendTo(stringBuilder);
    }
}
