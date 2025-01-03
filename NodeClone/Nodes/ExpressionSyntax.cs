﻿namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(AliasQualifiedNameSyntax), typeDiscriminator: "AliasQualifiedNameSyntax")]
[JsonDerivedType(typeof(GenericNameSyntax), typeDiscriminator: "GenericNameSyntax")]
[JsonDerivedType(typeof(IdentifierNameSyntax), typeDiscriminator: "IdentifierNameSyntax")]
[JsonDerivedType(typeof(QualifiedNameSyntax), typeDiscriminator: "QualifiedNameSyntax")]
[JsonDerivedType(typeof(RefTypeSyntax), typeDiscriminator: "RefTypeSyntax")]
[JsonDerivedType(typeof(PredefinedTypeSyntax), typeDiscriminator: "PredefinedTypeSyntax")]
[JsonDerivedType(typeof(ArrayTypeSyntax), typeDiscriminator: "ArrayTypeSyntax")]
[JsonDerivedType(typeof(PointerTypeSyntax), typeDiscriminator: "PointerTypeSyntax")]
[JsonDerivedType(typeof(FunctionPointerTypeSyntax), typeDiscriminator: "FunctionPointerTypeSyntax")]
[JsonDerivedType(typeof(NullableTypeSyntax), typeDiscriminator: "NullableTypeSyntax")]
[JsonDerivedType(typeof(TupleTypeSyntax), typeDiscriminator: "TupleTypeSyntax")]
[JsonDerivedType(typeof(OmittedTypeArgumentSyntax), typeDiscriminator: "OmittedTypeArgumentSyntax")]
[JsonDerivedType(typeof(ScopedTypeSyntax), typeDiscriminator: "ScopedTypeSyntax")]
[JsonDerivedType(typeof(AnonymousMethodExpressionSyntax), typeDiscriminator: "AnonymousMethodExpressionSyntax")]
[JsonDerivedType(typeof(ParenthesizedLambdaExpressionSyntax), typeDiscriminator: "ParenthesizedLambdaExpressionSyntax")]
[JsonDerivedType(typeof(SimpleLambdaExpressionSyntax), typeDiscriminator: "SimpleLambdaExpressionSyntax")]
[JsonDerivedType(typeof(StackAllocArrayCreationExpressionSyntax), typeDiscriminator: "StackAllocArrayCreationExpressionSyntax")]
[JsonDerivedType(typeof(ParenthesizedExpressionSyntax), typeDiscriminator: "ParenthesizedExpressionSyntax")]
[JsonDerivedType(typeof(TupleExpressionSyntax), typeDiscriminator: "TupleExpressionSyntax")]
[JsonDerivedType(typeof(PrefixUnaryExpressionSyntax), typeDiscriminator: "PrefixUnaryExpressionSyntax")]
[JsonDerivedType(typeof(AwaitExpressionSyntax), typeDiscriminator: "AwaitExpressionSyntax")]
[JsonDerivedType(typeof(PostfixUnaryExpressionSyntax), typeDiscriminator: "PostfixUnaryExpressionSyntax")]
[JsonDerivedType(typeof(MemberAccessExpressionSyntax), typeDiscriminator: "MemberAccessExpressionSyntax")]
[JsonDerivedType(typeof(ConditionalAccessExpressionSyntax), typeDiscriminator: "ConditionalAccessExpressionSyntax")]
[JsonDerivedType(typeof(MemberBindingExpressionSyntax), typeDiscriminator: "MemberBindingExpressionSyntax")]
[JsonDerivedType(typeof(ElementBindingExpressionSyntax), typeDiscriminator: "ElementBindingExpressionSyntax")]
[JsonDerivedType(typeof(RangeExpressionSyntax), typeDiscriminator: "RangeExpressionSyntax")]
[JsonDerivedType(typeof(ImplicitElementAccessSyntax), typeDiscriminator: "ImplicitElementAccessSyntax")]
[JsonDerivedType(typeof(BinaryExpressionSyntax), typeDiscriminator: "BinaryExpressionSyntax")]
[JsonDerivedType(typeof(AssignmentExpressionSyntax), typeDiscriminator: "AssignmentExpressionSyntax")]
[JsonDerivedType(typeof(ConditionalExpressionSyntax), typeDiscriminator: "ConditionalExpressionSyntax")]
[JsonDerivedType(typeof(ThisExpressionSyntax), typeDiscriminator: "ThisExpressionSyntax")]
[JsonDerivedType(typeof(BaseExpressionSyntax), typeDiscriminator: "BaseExpressionSyntax")]
[JsonDerivedType(typeof(LiteralExpressionSyntax), typeDiscriminator: "LiteralExpressionSyntax")]
[JsonDerivedType(typeof(MakeRefExpressionSyntax), typeDiscriminator: "MakeRefExpressionSyntax")]
[JsonDerivedType(typeof(RefTypeExpressionSyntax), typeDiscriminator: "RefTypeExpressionSyntax")]
[JsonDerivedType(typeof(RefValueExpressionSyntax), typeDiscriminator: "RefValueExpressionSyntax")]
[JsonDerivedType(typeof(CheckedExpressionSyntax), typeDiscriminator: "CheckedExpressionSyntax")]
[JsonDerivedType(typeof(DefaultExpressionSyntax), typeDiscriminator: "DefaultExpressionSyntax")]
[JsonDerivedType(typeof(TypeOfExpressionSyntax), typeDiscriminator: "TypeOfExpressionSyntax")]
[JsonDerivedType(typeof(SizeOfExpressionSyntax), typeDiscriminator: "SizeOfExpressionSyntax")]
[JsonDerivedType(typeof(InvocationExpressionSyntax), typeDiscriminator: "InvocationExpressionSyntax")]
[JsonDerivedType(typeof(ElementAccessExpressionSyntax), typeDiscriminator: "ElementAccessExpressionSyntax")]
[JsonDerivedType(typeof(DeclarationExpressionSyntax), typeDiscriminator: "DeclarationExpressionSyntax")]
[JsonDerivedType(typeof(CastExpressionSyntax), typeDiscriminator: "CastExpressionSyntax")]
[JsonDerivedType(typeof(RefExpressionSyntax), typeDiscriminator: "RefExpressionSyntax")]
[JsonDerivedType(typeof(InitializerExpressionSyntax), typeDiscriminator: "InitializerExpressionSyntax")]
[JsonDerivedType(typeof(ImplicitObjectCreationExpressionSyntax), typeDiscriminator: "ImplicitObjectCreationExpressionSyntax")]
[JsonDerivedType(typeof(ObjectCreationExpressionSyntax), typeDiscriminator: "ObjectCreationExpressionSyntax")]
[JsonDerivedType(typeof(WithExpressionSyntax), typeDiscriminator: "WithExpressionSyntax")]
[JsonDerivedType(typeof(AnonymousObjectCreationExpressionSyntax), typeDiscriminator: "AnonymousObjectCreationExpressionSyntax")]
[JsonDerivedType(typeof(ArrayCreationExpressionSyntax), typeDiscriminator: "ArrayCreationExpressionSyntax")]
[JsonDerivedType(typeof(ImplicitArrayCreationExpressionSyntax), typeDiscriminator: "ImplicitArrayCreationExpressionSyntax")]
[JsonDerivedType(typeof(ImplicitStackAllocArrayCreationExpressionSyntax), typeDiscriminator: "ImplicitStackAllocArrayCreationExpressionSyntax")]
[JsonDerivedType(typeof(CollectionExpressionSyntax), typeDiscriminator: "CollectionExpressionSyntax")]
[JsonDerivedType(typeof(QueryExpressionSyntax), typeDiscriminator: "QueryExpressionSyntax")]
[JsonDerivedType(typeof(OmittedArraySizeExpressionSyntax), typeDiscriminator: "OmittedArraySizeExpressionSyntax")]
[JsonDerivedType(typeof(InterpolatedStringExpressionSyntax), typeDiscriminator: "InterpolatedStringExpressionSyntax")]
[JsonDerivedType(typeof(IsPatternExpressionSyntax), typeDiscriminator: "IsPatternExpressionSyntax")]
[JsonDerivedType(typeof(ThrowExpressionSyntax), typeDiscriminator: "ThrowExpressionSyntax")]
[JsonDerivedType(typeof(SwitchExpressionSyntax), typeDiscriminator: "SwitchExpressionSyntax")]
public abstract class ExpressionSyntax : ExpressionOrPatternSyntax
{
    public static ExpressionSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax node, SyntaxNode? parent)
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
            _ => null!,
        };
    }
}
