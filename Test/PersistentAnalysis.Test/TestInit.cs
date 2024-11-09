namespace PersistentAnalysis.Test;

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

    [Test]
    public void TestDeserialization()
    {
        Persist.Parse("{\"Name\":\"InitCommand\",\"InitCommand\":{\"ClientGuid\":\"f54476ed-c30b-4d3b-949f-a01a75b57f7d\",\"Version\":\"1.0.0.1\"}}");
    }
}
