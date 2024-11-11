namespace PersistentAnalysis.Test;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework;
using ProcessCommunication;

public static class TestTools
{
    public const int ExitDelay = 20;
    public const string TestAnalyzer = "SampleAnalyzer.dll";

    public static async Task WaitDelay(TimeSpan delay)
    {
        TimeSpan MinZeroDelay = TimeSpan.FromSeconds(Math.Max(0, delay.TotalSeconds));
        await Task.Delay(MinZeroDelay).ConfigureAwait(false);
    }
    /*
    private static readonly IEnumerable<string> DefaultNamespaces = new[]
    {
        "System",
        "System.IO",
        "System.Net",
        "System.Linq",
        "System.Text",
        "System.Text.RegularExpressions",
        "System.Collections.Generic"
    };

    private static string RuntimePath = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8.1\";

    private static readonly IEnumerable<MetadataReference> DefaultReferences = new[]
    {
        MetadataReference.CreateFromFile($"{RuntimePath}mscorlib.dll"),
        MetadataReference.CreateFromFile($"{RuntimePath}System.dll"),
        MetadataReference.CreateFromFile($"{RuntimePath}System.Core.dll"),
    };

    private static readonly CSharpCompilationOptions DefaultCompilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                                                                                 .WithOverflowChecks(true).WithOptimizationLevel(OptimizationLevel.Release)
                                                                                 .WithUsings(DefaultNamespaces);
    */
    public static NodeClone.CompilationUnitSyntax Compile(string text)
    {
        var ParsedSyntaxTree = SyntaxFactory.ParseSyntaxTree(text, CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp12), string.Empty);
        //var Compilation = CSharpCompilation.Create("Test.dll", new SyntaxTree[] { ParsedSyntaxTree }, DefaultReferences, DefaultCompilationOptions);
        //SyntaxTree SyntaxTree = Compilation.SyntaxTrees.FirstOrDefault();
        SyntaxTree SyntaxTree = ParsedSyntaxTree;
        CompilationUnitSyntax Root = (CompilationUnitSyntax)SyntaxTree.GetRoot();
        NodeClone.CompilationUnitSyntax RootClone = new(Root, parent: null);

        return RootClone;
    }
}
