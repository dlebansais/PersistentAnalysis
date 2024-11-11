namespace PersistentAnalysis.Test;

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using ProcessCommunication;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Init()
    {
        Remote.Reset();

        // Ensures the debugger is started with a timeout before the first test is run.
        Persist.InitAsync(TimeSpan.FromSeconds(5), string.Empty).Wait();
        _ = Persist.Exit(TimeSpan.Zero);
        Thread.Sleep(TimeSpan.FromSeconds(5));
    }
}
