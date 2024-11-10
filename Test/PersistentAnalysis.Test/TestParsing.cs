#pragma warning disable CA1849

namespace PersistentAnalysis.Test;

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using NUnit.Framework;
using ProcessCommunication;

[TestFixture]
public class TestParsing
{
    [Test]
    public void TestInit()
    {
        Assert.That(Persist.LastClientGuid, Is.EqualTo(Guid.Empty));
        Assert.That(Persist.LastClientVersion, Is.EqualTo(string.Empty));

        Guid TestGuid = new("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");
        const string TestVersion = "1.2.3";

        Persist.Parse($"{{\"Name\":\"InitCommand\",\"InitCommand\":{{\"ClientGuid\":\"{TestGuid}\",\"Version\":\"{TestVersion}\"}}}}");

        Assert.That(Persist.LastClientGuid, Is.EqualTo(TestGuid));
        Assert.That(Persist.LastClientVersion, Is.EqualTo(TestVersion));

        Persist.Parse($"{{\"Name\":\"InitCommand\",\"InitCommand\":{{\"ClientGuid\":\"\",\"Version\": null}}}}");

        Assert.That(Persist.LastClientGuid, Is.EqualTo(Guid.Empty));
        Assert.That(Persist.LastClientVersion, Is.EqualTo(string.Empty));
    }

    [Test]
    public void TestExitNoEvent()
    {
        ObservedDelay = TimeSpan.Zero;
        Persist.ExitRequested += OnExitRequested;

        Persist.Parse("{\"Name\":\"ExitCommand\",\"ExitCommand\":{\"Delay\":\"00:00:01\"}}");

        Persist.ExitRequested -= OnExitRequested;

        Assert.That(ObservedDelay, Is.EqualTo(TimeSpan.FromSeconds(1)));
    }

    [Test]
    public void TestExitWithEvent()
    {
        ObservedDelay = TimeSpan.Zero;

        Persist.Parse("{\"Name\":\"ExitCommand\",\"ExitCommand\":{\"Delay\":\"00:00:01\"}}");

        Assert.That(ObservedDelay, Is.EqualTo(TimeSpan.Zero));
    }

    private void OnExitRequested(object? sender, ExitRequestedEventArgs e)
    {
        ObservedDelay = e.Delay;
    }

    private TimeSpan ObservedDelay;

    [Test]
    public void TestUpdate()
    {
        Persist.Parse("{\"Name\":\"UpdateCommand\",\"UpdateCommand\":{\"DeviceId\":\"{C5F19A64-5DDD-4B91-9F08-C2119E501BFE}\",\"Root\":{\"Externs\":[],\"Usings\":[],\"AttributeLists\":[],\"Members\":[{\"$discriminator\":\"FileScopedNamespaceDeclarationSyntax\",\"AttributeLists\":[],\"NamespaceKeyword\":{\"Text\":\"namespace\"},\"Name\":{\"$discriminator\":\"IdentifierNameSyntax\",\"Identifier\":{\"Text\":\"Test\"},\"Parent\":{}},\"SemicolonToken\":{\"Text\":\";\"},\"Externs\":[],\"Usings\":[],\"Members\":[{\"$discriminator\":\"ClassDeclarationSyntax\",\"AttributeLists\":[],\"Keyword\":{\"Text\":\"class\"},\"Identifier\":{\"Text\":\"Foo\"},\"ConstraintClauses\":[],\"OpenBraceToken\":{\"Text\":\"{\"},\"Members\":[],\"CloseBraceToken\":{\"Text\":\"}\"},\"SemicolonToken\":{\"Text\":\"\"}}]}],\"EndOfFileToken\":{\"Text\":\"\"}}}}");
    }

    [Test]
    public void TestInvalidText1()
    {
        Persist.Parse(string.Empty);
    }

    [Test]
    public void TestInvalidText2()
    {
        Persist.Parse("null");
    }

    [Test]
    public void TestInvalidCommand()
    {
        _ = Assert.Throws<ArgumentException>(() => Persist.Parse("{\"Name\":\"None\"}"));
    }
}
