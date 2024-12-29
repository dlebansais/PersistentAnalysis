#pragma warning disable CA1849

namespace PersistentAnalysis.Test;

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using NUnit.Framework;
using ProcessCommunication;

[TestFixture]
[NonParallelizable]
internal class TestInitExit
{
    [Test]
    public async Task TestSuccess()
    {
        Remote.Reset();

        Stopwatch LaunchStopwatch = Stopwatch.StartNew();
        bool IsOpen;
        bool IsExitSent;

        _ = Assert.Throws<InvalidOperationException>(() => Persist.Exit(TimeSpan.Zero));

        IsOpen = Persist.Init(TimeSpan.FromSeconds(TestTools.ExitDelay), TestTools.TestAnalyzer);
        Assert.That(IsOpen, Is.False);

        _ = Assert.Throws<InvalidOperationException>(() => Persist.Exit(TimeSpan.Zero));

        await TestTools.WaitDelay(Timeouts.ProcessLaunchTimeout - TimeSpan.FromSeconds(1) - LaunchStopwatch.Elapsed).ConfigureAwait(true);

        IsOpen = Persist.Init(TimeSpan.FromSeconds(TestTools.ExitDelay), TestTools.TestAnalyzer);
        Assert.That(IsOpen, Is.True);

        IsExitSent = Persist.Exit(TimeSpan.FromSeconds(1));
        Assert.That(IsExitSent, Is.True);

        await Task.Delay(TimeSpan.FromSeconds(TestTools.ExitDelay + 10)).ConfigureAwait(true);
    }

    [Test]
    public async Task TestShortTimeout()
    {
        Remote.Reset();

        Stopwatch LaunchStopwatch = Stopwatch.StartNew();
        bool IsOpen;

        IsOpen = Persist.Init(TimeSpan.FromSeconds(1), TestTools.TestAnalyzer);
        Assert.That(IsOpen, Is.False);

        await TestTools.WaitDelay(Timeouts.ProcessLaunchTimeout + TimeSpan.FromSeconds(1) - LaunchStopwatch.Elapsed).ConfigureAwait(true);

        IsOpen = Persist.Init(TimeSpan.Zero, TestTools.TestAnalyzer);
        Assert.That(IsOpen, Is.False);

        await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(true);
    }

    [Test]
    public async Task TestAsyncSuccess()
    {
        Remote.Reset();

        bool IsOpen;

        IsOpen = await Persist.InitAsync(TimeSpan.FromSeconds(TestTools.ExitDelay), TestTools.TestAnalyzer).ConfigureAwait(true);
        Assert.That(IsOpen, Is.True);

        Remote.Reset();

        IsOpen = await Persist.InitAsync(TimeSpan.FromSeconds(TestTools.ExitDelay), TestTools.TestAnalyzer).ConfigureAwait(true);
        Assert.That(IsOpen, Is.False);

        await Task.Delay(TimeSpan.FromSeconds(TestTools.ExitDelay + 10)).ConfigureAwait(true);
    }

    [Test]
    public async Task TestAsyncShortDuration()
    {
        Remote.Reset();

        bool IsOpen;

        IsOpen = await Persist.InitAsync(TimeSpan.FromSeconds(5), TestTools.TestAnalyzer).ConfigureAwait(true);
        Assert.That(IsOpen, Is.True);

        Remote.Reset();

        IsOpen = await Persist.InitAsync(TimeSpan.Zero, TestTools.TestAnalyzer).ConfigureAwait(true);
        Assert.That(IsOpen, Is.False);

        await Task.Delay(TimeSpan.FromSeconds(15)).ConfigureAwait(true);
    }
}
