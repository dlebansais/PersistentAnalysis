namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class FunctionPointerUnmanagedCallingConventionListSyntax : SyntaxNode
{
    public FunctionPointerUnmanagedCallingConventionListSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.FunctionPointerUnmanagedCallingConventionListSyntax node, SyntaxNode? parent)
    {
        OpenBracketToken = Cloner.ToToken(node.OpenBracketToken);
        CallingConventions = Cloner.SeparatedListFrom<FunctionPointerUnmanagedCallingConventionSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.FunctionPointerUnmanagedCallingConventionSyntax>(node.CallingConventions, parent);
        CloseBracketToken = Cloner.ToToken(node.CloseBracketToken);
        Parent = parent;
    }

    public SyntaxToken OpenBracketToken { get; }
    public SeparatedSyntaxList<FunctionPointerUnmanagedCallingConventionSyntax> CallingConventions { get; }
    public SyntaxToken CloseBracketToken { get; }
    public SyntaxNode? Parent { get; }
}
