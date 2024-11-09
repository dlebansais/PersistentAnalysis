namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonDerivedType(typeof(AliasQualifiedNameSyntax))]
[JsonDerivedType(typeof(GenericNameSyntax))]
[JsonDerivedType(typeof(IdentifierNameSyntax))]
[JsonDerivedType(typeof(QualifiedNameSyntax))]
[JsonDerivedType(typeof(RefTypeSyntax))]
[JsonDerivedType(typeof(PredefinedTypeSyntax))]
[JsonDerivedType(typeof(ArrayTypeSyntax))]
[JsonDerivedType(typeof(PointerTypeSyntax))]
[JsonDerivedType(typeof(FunctionPointerTypeSyntax))]
[JsonDerivedType(typeof(NullableTypeSyntax))]
[JsonDerivedType(typeof(TupleTypeSyntax))]
[JsonDerivedType(typeof(OmittedTypeArgumentSyntax))]
[JsonDerivedType(typeof(ScopedTypeSyntax))]
[JsonDerivedType(typeof(AnonymousMethodExpressionSyntax))]
[JsonDerivedType(typeof(ParenthesizedLambdaExpressionSyntax))]
[JsonDerivedType(typeof(SimpleLambdaExpressionSyntax))]
[JsonDerivedType(typeof(StackAllocArrayCreationExpressionSyntax))]
[JsonDerivedType(typeof(ParenthesizedExpressionSyntax))]
[JsonDerivedType(typeof(TupleExpressionSyntax))]
[JsonDerivedType(typeof(PrefixUnaryExpressionSyntax))]
[JsonDerivedType(typeof(AwaitExpressionSyntax))]
[JsonDerivedType(typeof(PostfixUnaryExpressionSyntax))]
[JsonDerivedType(typeof(MemberAccessExpressionSyntax))]
[JsonDerivedType(typeof(ConditionalAccessExpressionSyntax))]
[JsonDerivedType(typeof(MemberBindingExpressionSyntax))]
[JsonDerivedType(typeof(ElementBindingExpressionSyntax))]
[JsonDerivedType(typeof(RangeExpressionSyntax))]
[JsonDerivedType(typeof(ImplicitElementAccessSyntax))]
[JsonDerivedType(typeof(BinaryExpressionSyntax))]
[JsonDerivedType(typeof(AssignmentExpressionSyntax))]
[JsonDerivedType(typeof(ConditionalExpressionSyntax))]
[JsonDerivedType(typeof(ThisExpressionSyntax))]
[JsonDerivedType(typeof(BaseExpressionSyntax))]
[JsonDerivedType(typeof(LiteralExpressionSyntax))]
[JsonDerivedType(typeof(MakeRefExpressionSyntax))]
[JsonDerivedType(typeof(RefTypeExpressionSyntax))]
[JsonDerivedType(typeof(RefValueExpressionSyntax))]
[JsonDerivedType(typeof(CheckedExpressionSyntax))]
[JsonDerivedType(typeof(DefaultExpressionSyntax))]
[JsonDerivedType(typeof(TypeOfExpressionSyntax))]
[JsonDerivedType(typeof(SizeOfExpressionSyntax))]
[JsonDerivedType(typeof(InvocationExpressionSyntax))]
[JsonDerivedType(typeof(ElementAccessExpressionSyntax))]
[JsonDerivedType(typeof(DeclarationExpressionSyntax))]
[JsonDerivedType(typeof(CastExpressionSyntax))]
[JsonDerivedType(typeof(RefExpressionSyntax))]
[JsonDerivedType(typeof(InitializerExpressionSyntax))]
[JsonDerivedType(typeof(ImplicitObjectCreationExpressionSyntax))]
[JsonDerivedType(typeof(ObjectCreationExpressionSyntax))]
[JsonDerivedType(typeof(WithExpressionSyntax))]
[JsonDerivedType(typeof(AnonymousObjectCreationExpressionSyntax))]
[JsonDerivedType(typeof(ArrayCreationExpressionSyntax))]
[JsonDerivedType(typeof(ImplicitArrayCreationExpressionSyntax))]
[JsonDerivedType(typeof(ImplicitStackAllocArrayCreationExpressionSyntax))]
[JsonDerivedType(typeof(CollectionExpressionSyntax))]
[JsonDerivedType(typeof(QueryExpressionSyntax))]
[JsonDerivedType(typeof(OmittedArraySizeExpressionSyntax))]
[JsonDerivedType(typeof(InterpolatedStringExpressionSyntax))]
[JsonDerivedType(typeof(IsPatternExpressionSyntax))]
[JsonDerivedType(typeof(ThrowExpressionSyntax))]
[JsonDerivedType(typeof(SwitchExpressionSyntax))]
[JsonDerivedType(typeof(DiscardPatternSyntax))]
[JsonDerivedType(typeof(DeclarationPatternSyntax))]
[JsonDerivedType(typeof(VarPatternSyntax))]
[JsonDerivedType(typeof(RecursivePatternSyntax))]
[JsonDerivedType(typeof(ConstantPatternSyntax))]
[JsonDerivedType(typeof(ParenthesizedPatternSyntax))]
[JsonDerivedType(typeof(RelationalPatternSyntax))]
[JsonDerivedType(typeof(TypePatternSyntax))]
[JsonDerivedType(typeof(BinaryPatternSyntax))]
[JsonDerivedType(typeof(UnaryPatternSyntax))]
[JsonDerivedType(typeof(ListPatternSyntax))]
[JsonDerivedType(typeof(SlicePatternSyntax))]
public abstract class ExpressionOrPatternSyntax : SyntaxNode
{
    public static ExpressionOrPatternSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionOrPatternSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.AliasQualifiedNameSyntax AsAliasQualifiedNameSyntax => new AliasQualifiedNameSyntax(AsAliasQualifiedNameSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.GenericNameSyntax AsGenericNameSyntax => new GenericNameSyntax(AsGenericNameSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax AsIdentifierNameSyntax => new IdentifierNameSyntax(AsIdentifierNameSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.QualifiedNameSyntax AsQualifiedNameSyntax => new QualifiedNameSyntax(AsQualifiedNameSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.RefTypeSyntax AsRefTypeSyntax => new RefTypeSyntax(AsRefTypeSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.PredefinedTypeSyntax AsPredefinedTypeSyntax => new PredefinedTypeSyntax(AsPredefinedTypeSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ArrayTypeSyntax AsArrayTypeSyntax => new ArrayTypeSyntax(AsArrayTypeSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.PointerTypeSyntax AsPointerTypeSyntax => new PointerTypeSyntax(AsPointerTypeSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.FunctionPointerTypeSyntax AsFunctionPointerTypeSyntax => new FunctionPointerTypeSyntax(AsFunctionPointerTypeSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.NullableTypeSyntax AsNullableTypeSyntax => new NullableTypeSyntax(AsNullableTypeSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.TupleTypeSyntax AsTupleTypeSyntax => new TupleTypeSyntax(AsTupleTypeSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.OmittedTypeArgumentSyntax AsOmittedTypeArgumentSyntax => new OmittedTypeArgumentSyntax(AsOmittedTypeArgumentSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ScopedTypeSyntax AsScopedTypeSyntax => new ScopedTypeSyntax(AsScopedTypeSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousMethodExpressionSyntax AsAnonymousMethodExpressionSyntax => new AnonymousMethodExpressionSyntax(AsAnonymousMethodExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedLambdaExpressionSyntax AsParenthesizedLambdaExpressionSyntax => new ParenthesizedLambdaExpressionSyntax(AsParenthesizedLambdaExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.SimpleLambdaExpressionSyntax AsSimpleLambdaExpressionSyntax => new SimpleLambdaExpressionSyntax(AsSimpleLambdaExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.StackAllocArrayCreationExpressionSyntax AsStackAllocArrayCreationExpressionSyntax => new StackAllocArrayCreationExpressionSyntax(AsStackAllocArrayCreationExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedExpressionSyntax AsParenthesizedExpressionSyntax => new ParenthesizedExpressionSyntax(AsParenthesizedExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.TupleExpressionSyntax AsTupleExpressionSyntax => new TupleExpressionSyntax(AsTupleExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.PrefixUnaryExpressionSyntax AsPrefixUnaryExpressionSyntax => new PrefixUnaryExpressionSyntax(AsPrefixUnaryExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.AwaitExpressionSyntax AsAwaitExpressionSyntax => new AwaitExpressionSyntax(AsAwaitExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.PostfixUnaryExpressionSyntax AsPostfixUnaryExpressionSyntax => new PostfixUnaryExpressionSyntax(AsPostfixUnaryExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.MemberAccessExpressionSyntax AsMemberAccessExpressionSyntax => new MemberAccessExpressionSyntax(AsMemberAccessExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ConditionalAccessExpressionSyntax AsConditionalAccessExpressionSyntax => new ConditionalAccessExpressionSyntax(AsConditionalAccessExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.MemberBindingExpressionSyntax AsMemberBindingExpressionSyntax => new MemberBindingExpressionSyntax(AsMemberBindingExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ElementBindingExpressionSyntax AsElementBindingExpressionSyntax => new ElementBindingExpressionSyntax(AsElementBindingExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.RangeExpressionSyntax AsRangeExpressionSyntax => new RangeExpressionSyntax(AsRangeExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitElementAccessSyntax AsImplicitElementAccessSyntax => new ImplicitElementAccessSyntax(AsImplicitElementAccessSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.BinaryExpressionSyntax AsBinaryExpressionSyntax => new BinaryExpressionSyntax(AsBinaryExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.AssignmentExpressionSyntax AsAssignmentExpressionSyntax => new AssignmentExpressionSyntax(AsAssignmentExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ConditionalExpressionSyntax AsConditionalExpressionSyntax => new ConditionalExpressionSyntax(AsConditionalExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ThisExpressionSyntax AsThisExpressionSyntax => new ThisExpressionSyntax(AsThisExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.BaseExpressionSyntax AsBaseExpressionSyntax => new BaseExpressionSyntax(AsBaseExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.LiteralExpressionSyntax AsLiteralExpressionSyntax => new LiteralExpressionSyntax(AsLiteralExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.MakeRefExpressionSyntax AsMakeRefExpressionSyntax => new MakeRefExpressionSyntax(AsMakeRefExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.RefTypeExpressionSyntax AsRefTypeExpressionSyntax => new RefTypeExpressionSyntax(AsRefTypeExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.RefValueExpressionSyntax AsRefValueExpressionSyntax => new RefValueExpressionSyntax(AsRefValueExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.CheckedExpressionSyntax AsCheckedExpressionSyntax => new CheckedExpressionSyntax(AsCheckedExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.DefaultExpressionSyntax AsDefaultExpressionSyntax => new DefaultExpressionSyntax(AsDefaultExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.TypeOfExpressionSyntax AsTypeOfExpressionSyntax => new TypeOfExpressionSyntax(AsTypeOfExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.SizeOfExpressionSyntax AsSizeOfExpressionSyntax => new SizeOfExpressionSyntax(AsSizeOfExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.InvocationExpressionSyntax AsInvocationExpressionSyntax => new InvocationExpressionSyntax(AsInvocationExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ElementAccessExpressionSyntax AsElementAccessExpressionSyntax => new ElementAccessExpressionSyntax(AsElementAccessExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.DeclarationExpressionSyntax AsDeclarationExpressionSyntax => new DeclarationExpressionSyntax(AsDeclarationExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.CastExpressionSyntax AsCastExpressionSyntax => new CastExpressionSyntax(AsCastExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.RefExpressionSyntax AsRefExpressionSyntax => new RefExpressionSyntax(AsRefExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.InitializerExpressionSyntax AsInitializerExpressionSyntax => new InitializerExpressionSyntax(AsInitializerExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitObjectCreationExpressionSyntax AsImplicitObjectCreationExpressionSyntax => new ImplicitObjectCreationExpressionSyntax(AsImplicitObjectCreationExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ObjectCreationExpressionSyntax AsObjectCreationExpressionSyntax => new ObjectCreationExpressionSyntax(AsObjectCreationExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.WithExpressionSyntax AsWithExpressionSyntax => new WithExpressionSyntax(AsWithExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousObjectCreationExpressionSyntax AsAnonymousObjectCreationExpressionSyntax => new AnonymousObjectCreationExpressionSyntax(AsAnonymousObjectCreationExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ArrayCreationExpressionSyntax AsArrayCreationExpressionSyntax => new ArrayCreationExpressionSyntax(AsArrayCreationExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitArrayCreationExpressionSyntax AsImplicitArrayCreationExpressionSyntax => new ImplicitArrayCreationExpressionSyntax(AsImplicitArrayCreationExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitStackAllocArrayCreationExpressionSyntax AsImplicitStackAllocArrayCreationExpressionSyntax => new ImplicitStackAllocArrayCreationExpressionSyntax(AsImplicitStackAllocArrayCreationExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.CollectionExpressionSyntax AsCollectionExpressionSyntax => new CollectionExpressionSyntax(AsCollectionExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.QueryExpressionSyntax AsQueryExpressionSyntax => new QueryExpressionSyntax(AsQueryExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.OmittedArraySizeExpressionSyntax AsOmittedArraySizeExpressionSyntax => new OmittedArraySizeExpressionSyntax(AsOmittedArraySizeExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringExpressionSyntax AsInterpolatedStringExpressionSyntax => new InterpolatedStringExpressionSyntax(AsInterpolatedStringExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.IsPatternExpressionSyntax AsIsPatternExpressionSyntax => new IsPatternExpressionSyntax(AsIsPatternExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ThrowExpressionSyntax AsThrowExpressionSyntax => new ThrowExpressionSyntax(AsThrowExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.SwitchExpressionSyntax AsSwitchExpressionSyntax => new SwitchExpressionSyntax(AsSwitchExpressionSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.DiscardPatternSyntax AsDiscardPatternSyntax => new DiscardPatternSyntax(AsDiscardPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.DeclarationPatternSyntax AsDeclarationPatternSyntax => new DeclarationPatternSyntax(AsDeclarationPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.VarPatternSyntax AsVarPatternSyntax => new VarPatternSyntax(AsVarPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.RecursivePatternSyntax AsRecursivePatternSyntax => new RecursivePatternSyntax(AsRecursivePatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ConstantPatternSyntax AsConstantPatternSyntax => new ConstantPatternSyntax(AsConstantPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedPatternSyntax AsParenthesizedPatternSyntax => new ParenthesizedPatternSyntax(AsParenthesizedPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.RelationalPatternSyntax AsRelationalPatternSyntax => new RelationalPatternSyntax(AsRelationalPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.TypePatternSyntax AsTypePatternSyntax => new TypePatternSyntax(AsTypePatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.BinaryPatternSyntax AsBinaryPatternSyntax => new BinaryPatternSyntax(AsBinaryPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.UnaryPatternSyntax AsUnaryPatternSyntax => new UnaryPatternSyntax(AsUnaryPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.ListPatternSyntax AsListPatternSyntax => new ListPatternSyntax(AsListPatternSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.SlicePatternSyntax AsSlicePatternSyntax => new SlicePatternSyntax(AsSlicePatternSyntax, parent),
            _ => null!,
        };
    }
}
