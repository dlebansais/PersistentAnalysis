﻿namespace PersistentAnalysis.Test;

using System;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class TestInit
{
    [Test]
    public async Task TestSuccess()
    {
        bool IsOpen;

        IsOpen = Persist.Init();

        Assert.That(IsOpen, Is.False);

        await Task.Delay(ProcessCommunication.Timeouts.ProcessLaunchTimeout / 2).ConfigureAwait(true);

        IsOpen = Persist.Init();
        Assert.That(IsOpen, Is.True);

        bool IsExitSEnt = Persist.Exit(TimeSpan.FromSeconds(1));
        Assert.That(IsExitSEnt, Is.True);

        await Task.Delay(TimeSpan.FromSeconds(10)).ConfigureAwait(true);
    }
}