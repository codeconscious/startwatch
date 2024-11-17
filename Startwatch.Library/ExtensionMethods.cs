using System;

namespace Startwatch.Library;

public static class ExtensionMethods
{
    /// <summary>
    /// Get a short, friendly, human-readable string representation of a TimeSpan.
    /// </summary>
    public static string ElapsedFriendly(this TimeSpan timeSpan)
    {
        if (timeSpan.TotalMilliseconds < 1000)
        {
            return timeSpan switch
            {
                { TotalMilliseconds: <1 } => $"{timeSpan.TotalNanoseconds:#,##0}ns",
                _                         => $"{timeSpan.TotalMilliseconds:#,##0}ms"
            };
        }

        int days = timeSpan.Days;
        int hours = timeSpan.Hours;
        int mins = timeSpan.Minutes;
        int secs = timeSpan.Seconds;

        var prependText = secs == 0 ? "exactly " : string.Empty;

        var hoursText = (days, hours) switch
        {
            (>0, _) or (_, >0) => $"{hours + (days * 24):#,##0}h",
            _ => string.Empty
        };

        var minsText = (hours, mins) switch
        {
            (>0, >0) => $"{mins:00}m",
            (_, >0)  => $"{mins:0}m",
            _ => string.Empty
        };

        var secsText = (hours, mins, secs) switch
        {
            (0, 0, >0)                 => timeSpan.ToString("s\\.ff") + "s",
            (>0, _, >0) or (_, >0, >0) => timeSpan.ToString("ss") + "s",
            (_, _, >0)                 => timeSpan.ToString("s") + "s",
            _ => string.Empty
        };

        return $"{prependText}{hoursText}{minsText}{secsText}";
    }
}
