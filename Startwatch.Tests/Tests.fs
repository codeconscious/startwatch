﻿module Tests

open System
open Xunit
open Startwatch.Library.Logic

[<Fact>]
let ``Throws for negative TimeSpans`` () =
    let timeSpan = TimeSpan.FromTicks(-8001)
    Assert.Throws<NotSupportedException>(fun _ -> format timeSpan :> obj)

[<Fact>]
let ``Zero timespans`` () =
    let timeSpan = TimeSpan.Zero
    let actual = format timeSpan
    let expected = "no time"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Millisecond ten-thousandths (with nanoseconds)`` () =
    let timeSpan = TimeSpan.FromMilliseconds(0.0001)
    let actual = format timeSpan
    let expected = "0.0001ms (100ns)"
    Assert.Equal(expected, actual)


[<Fact>]
let ``Milliseconds with 4 decimals`` () =
    let timeSpan = TimeSpan.FromMilliseconds(0.9598)
    let actual = format timeSpan
    let expected = "0.9598ms"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Millisecond thousandths (with nanoseconds)`` () =
    let timeSpan = TimeSpan.FromMilliseconds(0.001)
    let actual = format timeSpan
    let expected = "0.001ms (1,000ns)"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Millisecond hundredths`` () =
    let timeSpan = TimeSpan.FromMilliseconds(0.01)
    let actual = format timeSpan
    let expected = "0.01ms"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Millisecond tenths`` () =
    let timeSpan = TimeSpan.FromMilliseconds(0.1)
    let actual = format timeSpan
    let expected = "0.1ms"
    Assert.Equal(expected, actual)

[<Fact>]
let ``One millisecond`` () =
    let timeSpan = TimeSpan.FromMilliseconds(1)
    let actual = format timeSpan
    let expected = "1ms"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Double-digit milliseconds`` () =
    let timeSpan = TimeSpan.FromMilliseconds(99.0)
    let actual = format timeSpan
    let expected = "99ms"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Double-digit milliseconds with a small decimal`` () =
    let timeSpan = TimeSpan.FromMilliseconds(99.2)
    let actual = format timeSpan
    let expected = "99ms"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Double-digit milliseconds with a large decimal`` () =
    let timeSpan = TimeSpan.FromMilliseconds(99.9)
    let actual = format timeSpan
    let expected = "100ms"
    Assert.Equal(expected, actual)


[<Fact>]
let ``Triple-digit milliseconds`` () =
    let timeSpan = TimeSpan.FromMilliseconds(999.0)
    let actual = format timeSpan
    let expected = "999ms"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Triple-digit milliseconds with a small decimal`` () =
    let timeSpan = TimeSpan.FromMilliseconds(999.3)
    let actual = format timeSpan
    let expected = "999ms"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Triple-digit milliseconds with a large decimal`` () =
    let timeSpan = TimeSpan.FromMilliseconds(999.9)
    let actual = format timeSpan
    let expected = "1,000ms"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Single-digit seconds`` () =
    let timeSpan = TimeSpan(0, 0, 3)
    let actual = format timeSpan
    let expected = "3.00s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Single-digit seconds with 500 milliseconds`` () =
    let timeSpan = TimeSpan(0, 0, 0, 3, 500)
    let actual = format timeSpan
    let expected = "3.50s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Single-digit seconds with 520 milliseconds`` () =
    let timeSpan = TimeSpan(0, 0, 0, 3, 520)
    let actual = format timeSpan
    let expected = "3.52s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Single-digit minute with no seconds`` () =
    let timeSpan = TimeSpan(0, 1, 0)
    let actual = format timeSpan
    let expected = "exactly 1m"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Single-digit minute with single-digit seconds`` () =
    let timeSpan = TimeSpan(0, 1, 5)
    let actual = format timeSpan
    let expected = "1m05s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Single-digit minute with double-digit seconds`` () =
    let timeSpan = TimeSpan(0, 1, 30)
    let actual = format timeSpan
    let expected = "1m30s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Single-digit minute with maximum seconds`` () =
    let timeSpan = TimeSpan(0, 1, 59)
    let actual = format timeSpan
    let expected = "1m59s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Two-digit minutes with no seconds`` () =
    let timeSpan = TimeSpan(0, 59, 0)
    let actual = format timeSpan
    let expected = "exactly 59m"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Two-digit minutes with 30 seconds`` () =
    let timeSpan = TimeSpan(0, 59, 30)
    let actual = format timeSpan
    let expected = "59m30s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Single-digit hour with no minutes or seconds`` () =
    let timeSpan = TimeSpan(7, 0, 0)
    let actual = format timeSpan
    let expected = "exactly 7h"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Single-digit hour with single-digit minutes but no seconds`` () =
    let timeSpan = TimeSpan(7, 7, 0)
    let actual = format timeSpan
    let expected = "exactly 7h07m"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Single-digit hour with single-digit minutes and single-digit seconds`` () =
    let timeSpan = TimeSpan(7, 7, 4)
    let actual = format timeSpan
    let expected = "7h07m04s"
    Assert.Equal(expected, actual)

let ``Single-digit hour with double-digit minutes but no seconds`` () =
    let timeSpan = TimeSpan(7, 20, 0)
    let actual = format timeSpan
    let expected = "exactly 7h20m"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Single-digit hour without minutes but with seconds`` () =
    let timeSpan = TimeSpan(7, 0, 47)
    let actual = format timeSpan
    let expected = "7h47s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Double-digit hour with no minutes or seconds`` () =
    let timeSpan = TimeSpan(13, 0, 0)
    let actual = format timeSpan
    let expected = "exactly 13h"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Single-digit hour with single-digit minutes and with seconds`` () =
    let timeSpan = TimeSpan(1, 3, 8)
    let actual = format timeSpan
    let expected = "1h03m08s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Single-digit hour with double-digit minutes and with seconds`` () =
    let timeSpan = TimeSpan(1, 55, 8)
    let actual = format timeSpan
    let expected = "1h55m08s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Double-digit hour with single-digit minutes and with seconds`` () =
    let timeSpan = TimeSpan(12, 5, 8)
    let actual = format timeSpan
    let expected = "12h05m08s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Double-digit hour over 24 hours with maximum minutes and seconds`` () =
    let timeSpan = TimeSpan(36, 59, 59)
    let actual = format timeSpan
    let expected = "36h59m59s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Single-digit day with no minutes, hours, or seconds`` () =
    let timeSpan = TimeSpan(10, 0, 0, 0)
    let actual = format timeSpan
    let expected = "exactly 240h"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Single-digit day with no minutes, hours, but with single-digit seconds`` () =
    let timeSpan = TimeSpan(10, 0, 0, 2)
    let actual = format timeSpan
    let expected = "240h02s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Single-digit day with no hours, but with single-digit minutes seconds`` () =
    let timeSpan = TimeSpan(10, 0, 0, 2)
    let actual = format timeSpan
    let expected = "240h02s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Single-digit day with minutes, hours, and seconds`` () =
    let timeSpan = TimeSpan(4, 4, 59, 59)
    let actual = format timeSpan
    let expected = "100h59m59s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Triple-digit day with minutes, hours, and seconds`` () =
    let timeSpan = TimeSpan(100, 23, 59, 59)
    let actual = format timeSpan
    let expected = "2,423h59m59s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Maximum TimeSpan`` () =
    let timeSpan = TimeSpan.MaxValue
    let actual = format timeSpan
    let expected = "256,204,778h48m05s"
    Assert.Equal(expected, actual)
