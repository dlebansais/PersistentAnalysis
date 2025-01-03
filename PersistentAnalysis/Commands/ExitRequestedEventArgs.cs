﻿namespace PersistentAnalysis;

using System;

/// <summary>
/// Represents arguments of the <see cref="Persist.ExitRequested"/> event.
/// </summary>
/// <param name="delay">An optional delay before clean up.</param>
public class ExitRequestedEventArgs(TimeSpan delay) : EventArgs
{
    /// <summary>
    /// Gets the delay.
    /// </summary>
    public TimeSpan Delay { get; } = delay;
}
