#pragma warning disable CA1849

namespace PersistentAnalysis.Test;

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using NUnit.Framework;
using ProcessCommunication;

[TestFixture]
public class TestUpdate
{
    private const int ExitDelay = 20;

    [Test]
    [NonParallelizable]
    public async Task TestSuccess()
    {
        Remote.Reset();

        bool IsOpen = await Persist.InitAsync(TimeSpan.FromSeconds(ExitDelay)).ConfigureAwait(true);
        Assert.That(IsOpen, Is.True);

        var Root = TestTools.Compile(@"namespace Test;

public class Foo
{{
}}
");

        bool IsUpdated = Persist.Update(Root);
        Assert.That(IsUpdated, Is.True);

        _ = Persist.Exit(TimeSpan.Zero);

        await Task.Delay(TimeSpan.FromSeconds(ExitDelay + 10)).ConfigureAwait(true);
    }

    [Test]
    [NonParallelizable]
    public async Task TestUpdateError()
    {
        Remote.Reset();

        var Root = TestTools.Compile(@"namespace Test;

public class Foo
{{
}}
");

        _ = Assert.Throws<InvalidOperationException>(() => Persist.Update(Root));

        Stopwatch LaunchStopwatch = Stopwatch.StartNew();
        bool IsOpen;

        IsOpen = Persist.Init(TimeSpan.FromSeconds(ExitDelay));
        Assert.That(IsOpen, Is.False);

        _ = Assert.Throws<InvalidOperationException>(() => Persist.Update(Root));

        await TestTools.WaitDelay(Timeouts.ProcessLaunchTimeout - TimeSpan.FromSeconds(1) - LaunchStopwatch.Elapsed).ConfigureAwait(true);

        IsOpen = Persist.Init(TimeSpan.FromSeconds(ExitDelay));
        Assert.That(IsOpen, Is.True);

        bool IsUpdated = Persist.Update(Root);
        Assert.That(IsUpdated, Is.True);

        _ = Persist.Exit(TimeSpan.FromSeconds(1));

        await Task.Delay(TimeSpan.FromSeconds(ExitDelay + 10)).ConfigureAwait(true);
    }

    [Test]
    [NonParallelizable]
    public async Task TestSaturateUpdate()
    {
        Remote.Reset();

        int OldCapacity = Channel.Capacity;
        Channel.Capacity = 0x100;

        bool IsOpen = await Persist.InitAsync(TimeSpan.FromSeconds(ExitDelay)).ConfigureAwait(true);

        Channel.Capacity = OldCapacity;

        Assert.That(IsOpen, Is.True);

        var Root = TestTools.Compile(@"namespace Test;

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

        await Task.Delay(TimeSpan.FromSeconds(ExitDelay + 10)).ConfigureAwait(true);
    }

    [Test]
    [NonParallelizable]
    public async Task TestUpdateSpecificSolution()
    {
        Remote.Reset();

        bool IsOpen = await Persist.InitAsync(TimeSpan.FromSeconds(ExitDelay)).ConfigureAwait(true);
        Assert.That(IsOpen, Is.True);

        var Root = TestTools.Compile(@"namespace Test;

public class Foo
{{
}}
");

        bool IsUpdated = Persist.Update("CustomDeviceId", "CustomSolution", "CustomPath", Root);
        Assert.That(IsUpdated, Is.True);

        _ = Persist.Exit(TimeSpan.Zero);

        await Task.Delay(TimeSpan.FromSeconds(ExitDelay + 10)).ConfigureAwait(true);
    }
}
