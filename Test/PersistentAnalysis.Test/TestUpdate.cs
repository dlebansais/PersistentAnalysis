#pragma warning disable CA1849

namespace PersistentAnalysis.Test;

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using NodeClone;
using NUnit.Framework;
using ProcessCommunication;

[TestFixture]
[NonParallelizable]
internal class TestUpdate
{
    [Test]
    public async Task TestSuccess()
    {
        Remote.Reset();

        bool IsOpen = await Persist.InitAsync(TimeSpan.FromSeconds(TestTools.ExitDelay), TestTools.TestAnalyzer).ConfigureAwait(true);
        Assert.That(IsOpen, Is.True);

        Persist.DiagnosticChanged += OnDiagnosticChanged;

        CompilationUnitSyntax Root = TestTools.Compile(@"namespace Test;

public class Foo
{{
}}
");

        for (int i = 0; i < 10; i++)
        {
            if (i > 0)
                await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(true);

            bool IsUpdated = Persist.Update(Root);
            Assert.That(IsUpdated, Is.True);
        }

        Assert.That(LastSender, Is.Null);
        Assert.That(LastDiagnosticChangedEventArgs, Is.Not.Null);

        Persist.DiagnosticChanged -= OnDiagnosticChanged;

        _ = Persist.Exit(TimeSpan.Zero);

        await Task.Delay(TimeSpan.FromSeconds(TestTools.ExitDelay + 10)).ConfigureAwait(true);
    }

    private void OnDiagnosticChanged(object? sender, DiagnosticChangedEventArgs args)
    {
        LastSender = sender;
        LastDiagnosticChangedEventArgs = args;
    }

    private object? LastSender;
    private DiagnosticChangedEventArgs? LastDiagnosticChangedEventArgs;

    [Test]
    public async Task TestSuccessNoReporting()
    {
        Remote.Reset();

        LastSender = null;
        LastDiagnosticChangedEventArgs = null;

        bool IsOpen = await Persist.InitAsync(TimeSpan.FromSeconds(TestTools.ExitDelay), TestTools.TestAnalyzer).ConfigureAwait(true);
        Assert.That(IsOpen, Is.True);

        CompilationUnitSyntax Root = TestTools.Compile(@"namespace Test;

public class Foo
{{
}}
");

        for (int i = 0; i < 10; i++)
        {
            if (i > 0)
                await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(true);

            bool IsUpdated = Persist.Update(Root);
            Assert.That(IsUpdated, Is.True);
        }

        Assert.That(LastSender, Is.Null);
        Assert.That(LastDiagnosticChangedEventArgs, Is.Null);

        _ = Persist.Exit(TimeSpan.Zero);

        await Task.Delay(TimeSpan.FromSeconds(TestTools.ExitDelay + 10)).ConfigureAwait(true);
    }

    [Test]
    public async Task TestUpdateError()
    {
        Remote.Reset();

        CompilationUnitSyntax Root = TestTools.Compile(@"namespace Test;

public class Foo
{{
}}
");

        _ = Assert.Throws<InvalidOperationException>(() => Persist.Update(Root));

        Stopwatch LaunchStopwatch = Stopwatch.StartNew();
        bool IsOpen;

        IsOpen = Persist.Init(TimeSpan.FromSeconds(TestTools.ExitDelay), TestTools.TestAnalyzer);
        Assert.That(IsOpen, Is.False);

        _ = Assert.Throws<InvalidOperationException>(() => Persist.Update(Root));

        await TestTools.WaitDelay(Timeouts.ProcessLaunchTimeout - TimeSpan.FromSeconds(1) - LaunchStopwatch.Elapsed).ConfigureAwait(true);

        IsOpen = Persist.Init(TimeSpan.FromSeconds(TestTools.ExitDelay), TestTools.TestAnalyzer);
        Assert.That(IsOpen, Is.True);

        bool IsUpdated = Persist.Update(Root);
        Assert.That(IsUpdated, Is.True);

        _ = Persist.Exit(TimeSpan.FromSeconds(1));

        await Task.Delay(TimeSpan.FromSeconds(TestTools.ExitDelay + 10)).ConfigureAwait(true);
    }

    [Test]
    public async Task TestSaturateUpdate()
    {
        Remote.Reset();

        int OldCapacity = Channel.Capacity;
        Channel.Capacity = 0x100;

        bool IsOpen = await Persist.InitAsync(TimeSpan.FromSeconds(TestTools.ExitDelay), TestTools.TestAnalyzer).ConfigureAwait(true);

        Channel.Capacity = OldCapacity;

        Assert.That(IsOpen, Is.True);

        CompilationUnitSyntax Root = TestTools.Compile(@"namespace Test;

public class Foo
{{
}}
");

        bool IsUpdated;
        do
        {
            IsUpdated = Persist.Update(Root);
        }
        while (IsUpdated);

        _ = Persist.Exit(TimeSpan.Zero);

        await Task.Delay(TimeSpan.FromSeconds(TestTools.ExitDelay + 10)).ConfigureAwait(true);
    }

    [Test]
    public async Task TestUpdateSpecificSolution()
    {
        Remote.Reset();

        bool IsOpen = await Persist.InitAsync(TimeSpan.FromSeconds(TestTools.ExitDelay), TestTools.TestAnalyzer).ConfigureAwait(true);
        Assert.That(IsOpen, Is.True);

        CompilationUnitSyntax Root = TestTools.Compile(@"namespace Test;

public class Foo
{{
}}
");

        bool IsUpdated = Persist.Update("CustomDeviceId", "CustomSolution", "CustomPath", Root);
        Assert.That(IsUpdated, Is.True);

        _ = Persist.Exit(TimeSpan.Zero);

        await Task.Delay(TimeSpan.FromSeconds(TestTools.ExitDelay + 10)).ConfigureAwait(true);
    }
}
