namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ParenthesizedLambdaExpressionSyntax : LambdaExpressionSyntax
{
    public ParenthesizedLambdaExpressionSyntax()
    {
        AsyncKeyword = null!;
        AttributeLists = null!;
        ReturnType = null!;
        ParameterList = null!;
        ArrowToken = null!;
        Block = null!;
        ExpressionBody = null!;
        Parent = null;
    }

    public ParenthesizedLambdaExpressionSyntax(Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedLambdaExpressionSyntax node, SyntaxNode? parent)
    {
        AsyncKeyword = Cloner.ToToken(node.AsyncKeyword);
        AttributeLists = Cloner.ListFrom<AttributeListSyntax, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax>(node.AttributeLists, this);
        ReturnType = node.ReturnType is null ? null : TypeSyntax.From(node.ReturnType, this);
        ParameterList = new ParameterListSyntax(node.ParameterList, this);
        ArrowToken = Cloner.ToToken(node.ArrowToken);
        Block = node.Block is null ? null : new BlockSyntax(node.Block, this);
        ExpressionBody = node.ExpressionBody is null ? null : ExpressionSyntax.From(node.ExpressionBody, this);
        Parent = parent;
    }

    public SyntaxToken AsyncKeyword { get; init; }
    public SyntaxList<AttributeListSyntax> AttributeLists { get; init; }
    public TypeSyntax? ReturnType { get; init; }
    public ParameterListSyntax ParameterList { get; init; }
    public SyntaxToken ArrowToken { get; init; }
    public BlockSyntax? Block { get; init; }
    public ExpressionSyntax? ExpressionBody { get; init; }
    public SyntaxNode? Parent { get; init; }
}
