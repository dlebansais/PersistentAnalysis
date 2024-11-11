namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class SimpleLambdaExpressionSyntax : LambdaExpressionSyntax
{
    public SimpleLambdaExpressionSyntax()
    {
        AsyncKeyword = null!;
        AttributeLists = null!;
        Parameter = null!;
        ArrowToken = null!;
        Block = null!;
        ExpressionBody = null!;
        Parent = null;
    }

    public SimpleLambdaExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.SimpleLambdaExpressionSyntax node, SyntaxNode? parent)
    {
        AsyncKeyword = Cloner.ToToken(node.AsyncKeyword);
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        Parameter = new ParameterSyntax(node.Parameter, this);
        ArrowToken = Cloner.ToToken(node.ArrowToken);
        Block = node.Block is null ? null : new BlockSyntax(node.Block, this);
        ExpressionBody = node.ExpressionBody is null ? null : ExpressionSyntax.From(node.ExpressionBody, this);
        Parent = parent;
    }

    public SyntaxToken AsyncKeyword { get; init; }
    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public ParameterSyntax Parameter { get; init; }
    public SyntaxToken ArrowToken { get; init; }
    public BlockSyntax? Block { get; init; }
    public ExpressionSyntax? ExpressionBody { get; init; }
    public SyntaxNode? Parent { get; init; }
}
