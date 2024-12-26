namespace Startwatch.Library

open System
open System.Diagnostics

module Logic =
    let format (timespan: TimeSpan) =
        match timespan with
        | t when t.Ticks < 0 ->
            raise <| NotSupportedException("Negative TimeSpans are currently not supported.")
        | t when t.Ticks = 0 ->
            "no time"
        | t when t.TotalMilliseconds < 0.01 ->
            sprintf "%s (%s)"
                (t.TotalMilliseconds.ToString("#,##0.#####ms"))
                (t.TotalNanoseconds.ToString("#,##0ns"))
        | t when t.TotalMilliseconds < 1 ->
            sprintf "%s" (t.TotalMilliseconds.ToString("#,##0.#####ms"))
        | t when t.TotalMilliseconds < 1000 ->
            sprintf "%s" (t.TotalMilliseconds.ToString("#,##0ms"))
        | t ->
            let days = t.Days
            let hours = t.Hours
            let mins = t.Minutes
            let secs = t.Seconds

            let prependText = if secs = 0 then "exactly " else String.Empty

            let hourText =
                match (days, hours) with
                | d, _ when d > 0 -> sprintf "%s" ((hours + (days * 24)).ToString("#,##0h"))
                | _, h when h > 0 -> sprintf "%s" ((hours + (days * 24)).ToString("#,##0h"))
                | _ -> String.Empty

            let minText =
                match (hours, mins) with
                | h, m when h > 0 && m > 0 -> sprintf "%s" (m.ToString("00m"))
                | _, m when m > 0 -> sprintf "%s" (m.ToString("0m"))
                | _ -> String.Empty

            let secText =
                match (days, hours, mins, secs) with
                | d, _, 0, s when d > 0 && s > 0 -> sprintf "%ss" (t.ToString("ss"))
                | _, 0, 0, s when s > 0 -> sprintf "%ss" (t.ToString("s\\.ff"))
                | _, h, _, s when h > 0 && s > 0 -> sprintf "%ss" (t.ToString("ss"))
                | _, _, m, s when m > 0 && s > 0 -> sprintf "%ss" (t.ToString("ss"))
                | _, _, _, s when s > 0 -> sprintf "%s" (t.ToString("s"))
                | _ -> String.Empty

            $"{prependText}{hourText}{minText}{secText}"

open Logic

/// A simple wrapper for `System.Diagnostic.Stopwatch` class saves its start time
/// and provides friendly representations of the elapsed time.
type Watch() =
    let mutable startedAt = Stopwatch.GetTimestamp()

    /// Returns a formatted "friendly" version of the elapsed time.
    member _.ElapsedFriendly =
        format <| Stopwatch.GetElapsedTime(startedAt)

    /// Sets the start time for this instance to the current time.
    member _.Restart =
        startedAt <- Stopwatch.GetTimestamp()
