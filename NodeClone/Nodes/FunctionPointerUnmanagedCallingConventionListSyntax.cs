namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class FunctionPointerUnmanagedCallingConventionListSyntax : SyntaxNode
{
    public FunctionPointerUnmanagedCallingConventionListSyntax()
    {
        OpenBracketToken = null!;
        CallingConventions = null!;
        CloseBracketToken = null!;
        Parent = null;
    }

    public FunctionPointerUnmanagedCallingConventionListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.FunctionPointerUnmanagedCallingConventionListSyntax node, SyntaxNode? parent)
    {
        OpenBracketToken = Cloner.ToToken(node.OpenBracketToken);
        CallingConventions = Cloner.SeparatedListFrom<FunctionPointerUnmanagedCallingConventionSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.FunctionPointerUnmanagedCallingConventionSyntax>(node.CallingConventions, this);
        CloseBracketToken = Cloner.ToToken(node.CloseBracketToken);
        Parent = parent;
    }

    public SyntaxToken OpenBracketToken { get; init; }
    public SeparatedSyntaxList<FunctionPointerUnmanagedCallingConventionSyntax> CallingConventions { get; init; }
    public SyntaxToken CloseBracketToken { get; init; }
    public SyntaxNode? Parent { get; init; }
}
