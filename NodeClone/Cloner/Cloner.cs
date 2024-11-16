namespace NodeClone;

using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis.CSharp;

public static class Cloner
{
    public static SyntaxToken ToToken(Microsoft.CodeAnalysis.SyntaxToken token)
    {
        return new SyntaxToken(token.Text);
    }

    public static SyntaxTokenList ToTokenList(Microsoft.CodeAnalysis.SyntaxTokenList tokenList)
    {
        return new SyntaxTokenList(tokenList.ToList().ConvertAll(ToToken));
    }

    public static SyntaxList<TClone> ListFrom<TClone, TNode>(Microsoft.CodeAnalysis.SyntaxList<TNode> items, SyntaxNode? parent)
        where TClone : SyntaxNode
        where TNode : Microsoft.CodeAnalysis.SyntaxNode
    {
        SyntaxList<TClone> Result = new();

        foreach (var Item in items)
            Result.Add(Clone<TClone, TNode>(Item, parent));

        return Result;
    }

    public static SeparatedSyntaxList<TClone> SeparatedListFrom<TClone, TNode>(Microsoft.CodeAnalysis.SeparatedSyntaxList<TNode> items, SyntaxNode? parent)
        where TClone : SyntaxNode
        where TNode : Microsoft.CodeAnalysis.SyntaxNode
    {
        string Separator = items.SeparatorCount > 0 ? items.GetSeparator(0).Text : string.Empty;
        SeparatedSyntaxList <TClone> Result = new(Separator);

        foreach (var Item in items)
            Result.Add(Clone<TClone, TNode>(Item, parent));

        return Result;
    }

    public static TClone Clone<TClone, TNode>(TNode node, SyntaxNode? parent)
        where TClone : SyntaxNode
    {
        if (typeof(TNode).IsAbstract)
        {
            var StaticMethod = typeof(TClone).GetMethod("From", BindingFlags.Public | BindingFlags.Static)!;
            return (TClone)StaticMethod.Invoke(null, [node, parent])!;
        }
        else
        {
            return (TClone)Activator.CreateInstance(typeof(TClone), [node, parent])!;
        }
    }

    public static Microsoft.CodeAnalysis.CSharp.Syntax.CompilationUnitSyntax Reconstruct(CompilationUnitSyntax root)
    {
        StringBuilder StringBuilder = new();
        root.AppendTo(StringBuilder);
        string Text = StringBuilder.ToString();

        Microsoft.CodeAnalysis.SyntaxTree SyntaxTree = SyntaxFactory.ParseSyntaxTree(Text, CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp12), string.Empty);

        return (Microsoft.CodeAnalysis.CSharp.Syntax.CompilationUnitSyntax)SyntaxTree.GetRoot();
    }
}
