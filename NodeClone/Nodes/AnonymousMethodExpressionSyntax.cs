namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class AnonymousMethodExpressionSyntax : AnonymousFunctionExpressionSyntax
{
    public AnonymousMethodExpressionSyntax()
    {
        AsyncKeyword = null!;
        DelegateKeyword = null!;
        ParameterList = null!;
        Block = null!;
        ExpressionBody = null!;
        Parent = null;
    }

    public AnonymousMethodExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousMethodExpressionSyntax node, SyntaxNode? parent)
    {
        AsyncKeyword = Cloner.ToToken(node.AsyncKeyword);
        DelegateKeyword = Cloner.ToToken(node.DelegateKeyword);
        ParameterList = node.ParameterList is null ? null : new ParameterListSyntax(node.ParameterList, this);
        Block = new BlockSyntax(node.Block, this);
        ExpressionBody = node.ExpressionBody is null ? null : ExpressionSyntax.From(node.ExpressionBody, this);
        Parent = parent;
    }

    public SyntaxToken AsyncKeyword { get; init; }
    public SyntaxToken DelegateKeyword { get; init; }
    public ParameterListSyntax? ParameterList { get; init; }
    public BlockSyntax Block { get; init; }
    public ExpressionSyntax? ExpressionBody { get; init; }
    public SyntaxNode? Parent { get; init; }
}
