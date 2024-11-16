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

    public static NodeClone.CompilationUnitSyntax Compile(string text)
    {
        SyntaxTree SyntaxTree = SyntaxFactory.ParseSyntaxTree(text, CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp12), string.Empty);
        CompilationUnitSyntax Root = (CompilationUnitSyntax)SyntaxTree.GetRoot();
        NodeClone.CompilationUnitSyntax RootClone = new(Root);

        return RootClone;
    }
}
