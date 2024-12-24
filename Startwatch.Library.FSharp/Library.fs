namespace Startwatch.Library.FSharp

open System
open System.Diagnostics

module Startwatch =
    type Watch() =
        let startedAt = Stopwatch.GetTimestamp()

        let elapsedFriendly (startedAt: int64) =
            let timeSpan = Stopwatch.GetElapsedTime(startedAt)
            match timeSpan with
            | t when t.TotalMilliseconds < 1 -> sprintf "%s" (t.TotalNanoseconds.ToString("#,##0ns"))
            | t when t.TotalMilliseconds < 1000 -> sprintf "%s" (t.TotalMilliseconds.ToString("#,##0ms"))
            | t ->
                let days = t.Days
                let hours = t.Hours
                let mins = t.Minutes
                let secs = t.Seconds

                let prependText = if secs = 0 then "exactly " else String.Empty

                let hoursText =
                    match (days, hours) with
                    | d, _ when d > 0 -> sprintf "%s" ((hours + (days * 24)).ToString("#,##0h"))
                    | _, h when h > 0 -> sprintf "%s" ((hours + (days * 24)).ToString("#,##0h"))
                    | _ -> String.Empty

                let minsText =
                    match (hours, mins) with
                    | h, m when h > 0 && m > 0 -> sprintf "%s" (m.ToString("00m"))
                    | _, m when m > 0 -> sprintf "%s" (m.ToString("0m"))
                    | _ -> String.Empty

                let secsText =
                    match (hours, mins, secs) with
                    | 0, 0, s when s > 0 -> sprintf "%s\\.%ff" (t.ToString("s")) (t.TotalSeconds % 1.0)
                    | h, _, s when h > 0 && s > 0 -> sprintf "%ss" (t.ToString("ss"))
                    | _, m, s when m > 0 && s > 0 -> sprintf "%ss" (t.ToString("ss"))
                    | _, _, s when s > 0 -> sprintf "%ss" (t.ToString("s"))
                    | _ -> String.Empty

                $"{prependText}{hoursText}{minsText}{secsText}"

        member this.ElapsedFriendly = elapsedFriendly startedAt
