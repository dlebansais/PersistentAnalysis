namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class FunctionPointerCallingConventionSyntax : SyntaxNode
{
    public FunctionPointerCallingConventionSyntax()
    {
        ManagedOrUnmanagedKeyword = null!;
        UnmanagedCallingConventionList = null!;
        Parent = null;
    }

    public FunctionPointerCallingConventionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.FunctionPointerCallingConventionSyntax node, SyntaxNode? parent)
    {
        ManagedOrUnmanagedKeyword = Cloner.ToToken(node.ManagedOrUnmanagedKeyword);
        UnmanagedCallingConventionList = node.UnmanagedCallingConventionList is null ? null : new FunctionPointerUnmanagedCallingConventionListSyntax(node.UnmanagedCallingConventionList, this);
        Parent = parent;
    }

    public SyntaxToken ManagedOrUnmanagedKeyword { get; init; }
    public FunctionPointerUnmanagedCallingConventionListSyntax? UnmanagedCallingConventionList { get; init; }
    public SyntaxNode? Parent { get; init; }

    public override void AppendTo(StringBuilder stringBuilder)
    {
        ManagedOrUnmanagedKeyword.AppendTo(stringBuilder);
        UnmanagedCallingConventionList?.AppendTo(stringBuilder);
    }
}
