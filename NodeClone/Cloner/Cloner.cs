namespace NodeClone;

using System;
using System.Reflection;

public static class Cloner
{
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
        SeparatedSyntaxList<TClone> Result = new();

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
}
