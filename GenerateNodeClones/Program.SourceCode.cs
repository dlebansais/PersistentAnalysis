﻿namespace GenerateNodeClones;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;

internal partial class Program
{
    private static void GenerateSourceCode(Dictionary<Type, NodeCloneInfo?> nodeTypes, string folderPath)
    {
        foreach (KeyValuePair<Type, NodeCloneInfo?> Entry in nodeTypes)
        {
            NodeCloneInfo? NodeCloneInfo = Entry.Value;
            Debug.Assert(NodeCloneInfo is not null);

            GenerateSourceCode(nodeTypes, Entry.Key, NodeCloneInfo, folderPath);
        }
    }

    private static void GenerateSourceCode(Dictionary<Type, NodeCloneInfo?> nodeTypes, Type type, NodeCloneInfo nodeCloneInfo, string folderPath)
    {
        if (nodeCloneInfo.IsAbstract)
            GenerateSourceCodeAbstract(nodeTypes, type, nodeCloneInfo, folderPath);
        else
            GenerateSourceCodeNonAbstract(type, nodeCloneInfo, folderPath);
    }

    private static void GenerateSourceCodeAbstract(Dictionary<Type, NodeCloneInfo?> nodeTypes, Type type, NodeCloneInfo nodeCloneInfo, string folderPath)
    {
        string ClassName = type.Name;
        string FileName = $"{folderPath}/{ClassName}.cs";
        using FileStream Stream = new(FileName, FileMode.Create, FileAccess.Write);
        using StreamWriter writer = new(Stream, Encoding.UTF8);

        string BaseClassName = nodeCloneInfo.BaseClassName ?? nameof(Microsoft.CodeAnalysis.SyntaxNode);

        string JsonString = string.Empty;

        foreach (KeyValuePair<Type, NodeCloneInfo?> Entry in nodeTypes)
        {
            Type OtherType = Entry.Key;
            if (!OtherType.IsAbstract && type.IsAssignableFrom(OtherType))
            {
                string OtherTypeName = OtherType.Name;
                JsonString += @$"
[JsonDerivedType(typeof({OtherTypeName}), typeDiscriminator: ""{OtherTypeName}"")]";
            }
        }

        if (JsonString != string.Empty)
        {
            JsonString = @$"
[JsonPolymorphic(TypeDiscriminatorPropertyName = ""$discriminator"")]" + JsonString;
        }

        string ConversionString = string.Empty;

        foreach (KeyValuePair<Type, NodeCloneInfo?> Entry in nodeTypes)
        {
            Type OtherType = Entry.Key;
            if (!OtherType.IsAbstract && type.IsAssignableFrom(OtherType))
            {
                if (ConversionString.Length > 0)
                    ConversionString += @$"
";

                string OtherTypeName = OtherType.Name;
                ConversionString += $"            Microsoft.CodeAnalysis.CSharp.Syntax.{OtherTypeName} As{OtherTypeName} => new {OtherTypeName}(As{OtherTypeName}, parent),";
            }
        }

        writer.WriteLine(@$"namespace NodeClone;

using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
{JsonString}
public abstract class {ClassName} : {BaseClassName}
{{
    public static {ClassName} From(Microsoft.CodeAnalysis.CSharp.Syntax.{ClassName} node, SyntaxNode? parent)
    {{
        return node switch
        {{
{ConversionString}
            _ => null!,
        }};
    }}
}}");
    }

    private static void GenerateSourceCodeNonAbstract(Type type, NodeCloneInfo nodeCloneInfo, string folderPath)
    {
        string ClassName = type.Name;
        string FileName = $"{folderPath}/{ClassName}.cs";
        using FileStream Stream = new(FileName, FileMode.Create, FileAccess.Write);
        using StreamWriter writer = new(Stream, Encoding.UTF8);

        string BaseClassName = nodeCloneInfo.BaseClassName ?? nameof(Microsoft.CodeAnalysis.SyntaxNode);
        bool IsNullParent = type.Name == nameof(CompilationUnitSyntax);

        string EmptyConstructorInitCode = string.Empty;

        foreach (KeyValuePair<string, NodePropertyInfo> Entry in nodeCloneInfo.PropertiesInfo)
        {
            if (EmptyConstructorInitCode.Length > 0)
                EmptyConstructorInitCode += @$"
";

            string PropertyName = Entry.Key;
            NodePropertyInfo NodePropertyInfo = Entry.Value;

            string InitCode = GenerateEmptyInitCode(PropertyName, NodePropertyInfo);
            EmptyConstructorInitCode += $"        {InitCode}";
        }

        string ConstructorInitCode = string.Empty;
        string ParentParameter = IsNullParent ? string.Empty : ", SyntaxNode? parent";

        foreach (KeyValuePair<string, NodePropertyInfo> Entry in nodeCloneInfo.PropertiesInfo)
        {
            if (ConstructorInitCode.Length > 0)
                ConstructorInitCode += @$"
";

            string PropertyName = Entry.Key;
            NodePropertyInfo NodePropertyInfo = Entry.Value;

            string InitCode = GenerateInitCode(PropertyName, NodePropertyInfo, IsNullParent);

            ConstructorInitCode += $"        {InitCode}";
        }

        string PropertiesSourceCode = string.Empty;

        foreach (KeyValuePair<string, NodePropertyInfo> Entry in nodeCloneInfo.PropertiesInfo)
        {
            if (PropertiesSourceCode.Length > 0)
                PropertiesSourceCode += @$"
";

            string PropertyName = Entry.Key;
            NodePropertyInfo NodePropertyInfo = Entry.Value;

            string PropertySourceCode = GeneratePropertySourceCode(PropertyName, NodePropertyInfo);
            PropertiesSourceCode += $"    {PropertySourceCode}";
        }

        string StringBuilderSourceCode = string.Empty;

        foreach (KeyValuePair<string, NodePropertyInfo> Entry in nodeCloneInfo.PropertiesInfo)
        {
            string PropertyName = Entry.Key;
            if (PropertyName == "Parent")
                continue;

            if (StringBuilderSourceCode.Length > 0)
                StringBuilderSourceCode += @$"
";

            NodePropertyInfo NodePropertyInfo = Entry.Value;

            string PropertySourceCode = GenerateStringBuilderSourceCode(PropertyName, NodePropertyInfo);
            StringBuilderSourceCode += $"        {PropertySourceCode}";
        }

        writer.WriteLine(@$"namespace NodeClone;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class {ClassName} : {BaseClassName}
{{
    public {ClassName}()
    {{
{EmptyConstructorInitCode}
    }}

    public {ClassName}(Microsoft.CodeAnalysis.CSharp.Syntax.{ClassName} node{ParentParameter})
    {{
{ConstructorInitCode}
    }}

{PropertiesSourceCode}

    public override void AppendTo(StringBuilder stringBuilder)
    {{
{StringBuilderSourceCode}
    }}
}}");
    }

    private static string GenerateEmptyInitCode(string propertyName, NodePropertyInfo nodePropertyInfo)
    {
        string? ValueString;

        if (nodePropertyInfo.Node is Type NodeType && propertyName == "Parent")
            ValueString = "null";
        else
            ValueString = "null!";

        return $"{propertyName} = {ValueString};";
    }

    private static string GenerateInitCode(string propertyName, NodePropertyInfo nodePropertyInfo, bool isNullParent)
    {
        string? ValueString = null;

        if (nodePropertyInfo.IsToken)
        {
            ValueString = $"Cloner.ToToken(node.{propertyName})";
        }

        if (nodePropertyInfo.IsTokenList)
        {
            ValueString = $"Cloner.ToTokenList(node.{propertyName})";
        }

        if (nodePropertyInfo.Node is Type NodeType)
        {
            if (propertyName == "Parent")
                ValueString = isNullParent ? "null" : "parent";
            else if (NodeType.IsAbstract)
            {
                if (nodePropertyInfo.IsNullable)
                    ValueString = $"node.{propertyName} is null ? null : {NodeType.Name}.From(node.{propertyName}, this)";
                else
                    ValueString = $"{NodeType.Name}.From(node.{propertyName}, this)";
            }
            else
            {
                if (nodePropertyInfo.IsNullable)
                    ValueString = $"node.{propertyName} is null ? null : new {NodeType.Name}(node.{propertyName}, this)";
                else
                    ValueString = $"new {NodeType.Name}(node.{propertyName}, this)";
            }
        }

        if (nodePropertyInfo.List is Type ListType)
        {
            ValueString = $"Cloner.ListFrom<{ListType.Name}, Microsoft.CodeAnalysis.CSharp.Syntax.{ListType.Name}>(node.{propertyName}, this)";
        }

        if (nodePropertyInfo.SeparatedList is Type SeparatedListType)
        {
            ValueString = $"Cloner.SeparatedListFrom<{SeparatedListType.Name}, Microsoft.CodeAnalysis.CSharp.Syntax.{SeparatedListType.Name}>(node.{propertyName}, this)";
        }

        Debug.Assert(ValueString is not null);

        return $"{propertyName} = {ValueString};";
    }

    private static string GeneratePropertySourceCode(string propertyName, NodePropertyInfo nodePropertyInfo)
    {
        string? PropertyTypeString = null;

        if (nodePropertyInfo.IsToken)
            PropertyTypeString = "SyntaxToken";

        if (nodePropertyInfo.IsTokenList)
            PropertyTypeString = "SyntaxTokenList";

        if (nodePropertyInfo.Node is Type NodeType)
        {
            PropertyTypeString = $"{NodeType.Name}";
        }

        if (nodePropertyInfo.List is Type ListType)
        {
            PropertyTypeString = $"SyntaxList<{ListType.Name}>";
        }

        if (nodePropertyInfo.SeparatedList is Type SeparatedListType)
        {
            PropertyTypeString = $"SeparatedSyntaxList<{SeparatedListType.Name}>";
        }

        Debug.Assert(PropertyTypeString is not null);

        string? Nullability = nodePropertyInfo.IsNullable ? "?" : string.Empty;

        return $"public {PropertyTypeString}{Nullability} {propertyName} {{ get; init; }}";
    }

    private static string GenerateStringBuilderSourceCode(string propertyName, NodePropertyInfo nodePropertyInfo)
    {
        if (nodePropertyInfo.IsNullable)
            return $"{propertyName}?.AppendTo(stringBuilder);";
        else
            return $"{propertyName}.AppendTo(stringBuilder);";
    }
}
