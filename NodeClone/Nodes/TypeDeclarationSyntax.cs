namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[JsonDerivedType(typeof(ClassDeclarationSyntax))]
[JsonDerivedType(typeof(InterfaceDeclarationSyntax))]
[JsonDerivedType(typeof(RecordDeclarationSyntax))]
[JsonDerivedType(typeof(StructDeclarationSyntax))]
public abstract class TypeDeclarationSyntax : BaseTypeDeclarationSyntax
{
    public static TypeDeclarationSyntax From(Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax node, SyntaxNode? parent)
    {
        return node switch
        {
            Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax AsClassDeclarationSyntax => new ClassDeclarationSyntax(AsClassDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.InterfaceDeclarationSyntax AsInterfaceDeclarationSyntax => new InterfaceDeclarationSyntax(AsInterfaceDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.RecordDeclarationSyntax AsRecordDeclarationSyntax => new RecordDeclarationSyntax(AsRecordDeclarationSyntax, parent),
            Microsoft.CodeAnalysis.CSharp.Syntax.StructDeclarationSyntax AsStructDeclarationSyntax => new StructDeclarationSyntax(AsStructDeclarationSyntax, parent),
            _ => null!,
        };
    }
}
