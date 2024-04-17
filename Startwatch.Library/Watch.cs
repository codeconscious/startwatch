using System;
using System.Diagnostics;

namespace Startwatch.Library;

/// <summary>
/// A `Stopwatch` wrapper. Starts the enclosed `Stopwatch` upon instantiation.
/// </summary>
public sealed class Watch
{
    private readonly Stopwatch Stopwatch = new();

    /// <summary>
    /// Returns a formatted version of the elapsed time since the timer was started.
    /// </summary>
    /// <remarks>
    ///   Using ticks because .ElapsedMilliseconds can be wildly inaccurate.
    ///   (Reference: https://stackoverflow.com/q/5113750/11767771)
    ///
    ///   Also, use `Stopwatch.Elapsed.Ticks` over `Stopwatch.ElapsedTicks`.
    ///   For reasons of which I'm unware, the latter returns unexpected values.
    /// </remarks>
    public string ElapsedFriendly =>
        TimeSpan.FromTicks(Stopwatch.Elapsed.Ticks).ElapsedFriendly();

    /// <summary>
    /// A constructor that automatically starts the enclosed `Stopwatch`.
    /// </summary>
    public Watch()
    {
        Stopwatch.Start();
    }

    /// <summary>
    /// Stops time interval measurement, resets the elapsed time to zero, and starts measuring elapsed time.
    /// </summary>
    public void Restart()
    {
        Stopwatch.Restart();
    }
}
