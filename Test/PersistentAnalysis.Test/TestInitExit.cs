#pragma warning disable CA1849

namespace PersistentAnalysis.Test;

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using NUnit.Framework;
using ProcessCommunication;

[TestFixture]
public class TestInitExit
{
    private const int ExitDelay = 20;

    [Test]
    [NonParallelizable]
    public async Task TestSuccess()
    {
        Remote.Reset();

        Stopwatch LaunchStopwatch = Stopwatch.StartNew();
        bool IsOpen;
        bool IsExitSent;

        _ = Assert.Throws<InvalidOperationException>(() => Persist.Exit(TimeSpan.Zero));

        IsOpen = Persist.Init(TimeSpan.FromSeconds(ExitDelay));
        Assert.That(IsOpen, Is.False);

        _ = Assert.Throws<InvalidOperationException>(() => Persist.Exit(TimeSpan.Zero));

        await TestTools.WaitDelay(Timeouts.ProcessLaunchTimeout - TimeSpan.FromSeconds(1) - LaunchStopwatch.Elapsed).ConfigureAwait(true);

        IsOpen = Persist.Init(TimeSpan.FromSeconds(ExitDelay));
        Assert.That(IsOpen, Is.True);

        IsExitSent = Persist.Exit(TimeSpan.FromSeconds(1));
        Assert.That(IsExitSent, Is.True);

        await Task.Delay(TimeSpan.FromSeconds(ExitDelay + 2)).ConfigureAwait(true);
    }

    [Test]
    [NonParallelizable]
    public async Task TestShortTimeout()
    {
        Remote.Reset();

        Stopwatch LaunchStopwatch = Stopwatch.StartNew();
        bool IsOpen;

        IsOpen = Persist.Init(TimeSpan.FromSeconds(1));
        Assert.That(IsOpen, Is.False);

        await TestTools.WaitDelay(Timeouts.ProcessLaunchTimeout + TimeSpan.FromSeconds(1) - LaunchStopwatch.Elapsed).ConfigureAwait(true);

        IsOpen = Persist.Init(TimeSpan.FromSeconds(1));
        Assert.That(IsOpen, Is.False);

        await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(true);
    }

    [Test]
    [NonParallelizable]
    public async Task TestAsyncSuccess()
    {
        Remote.Reset();

        bool IsOpen;

        IsOpen = await Persist.InitAsync(TimeSpan.FromSeconds(ExitDelay)).ConfigureAwait(true);
        Assert.That(IsOpen, Is.True);

        Remote.Reset();

        IsOpen = await Persist.InitAsync(TimeSpan.FromSeconds(ExitDelay)).ConfigureAwait(true);
        Assert.That(IsOpen, Is.False);

        await Task.Delay(TimeSpan.FromSeconds(ExitDelay)).ConfigureAwait(true);
    }
}
