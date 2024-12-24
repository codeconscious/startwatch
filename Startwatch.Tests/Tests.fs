module Tests

open System
open Xunit
open Startwatch.Library.Extensions

[<Fact>]
let ``nanosecond with three digits are formatted correctly`` () =
    let timeSpan = TimeSpan.FromTicks(1) // 1 tick == 100 nanoseconds
    let actual = timeSpan.ElapsedFriendly()
    let expected = "100ns"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Nanoseconds_FiveDigits_FormatsCorrectly`` () =
    let timeSpan = TimeSpan.FromTicks(100L) // 1 tick == 100 nanoseconds
    let actual = timeSpan.ElapsedFriendly()
    let expected = "10,000ns"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Milliseconds_OneDigit_FormatsCorrectly`` () =
    let timeSpan = TimeSpan.FromMilliseconds(1.0)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "1ms"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Milliseconds_TwoDigits_FormatsCorrectly`` () =
    let timeSpan = TimeSpan.FromMilliseconds(99.0)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "99ms"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Milliseconds_ThreeDigits_FormatsCorrectly`` () =
    let timeSpan = TimeSpan.FromMilliseconds(999.0)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "999ms"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Milliseconds_ThreeDigitsWithSmallDecimal_FormatsCorrectly`` () =
    let timeSpan = TimeSpan.FromMilliseconds(999.3)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "999ms"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Milliseconds_ThreeDigitsWithLargeDecimal_FormatsCorrectly`` () =
    let timeSpan = TimeSpan.FromMilliseconds(999.9)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "1,000ms"
    Assert.Equal(expected, actual)

[<Fact>]
let ``SecondsOnly_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(0, 0, 3)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "3.00s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Seconds_With500Milliseconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(0, 0, 0, 3, 500)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "3.50s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Seconds_With520Milliseconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(0, 0, 0, 3, 520)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "3.52s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Minute_NoSeconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(0, 1, 0)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "exactly 1m"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Minute_30Seconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(0, 1, 30)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "1m30s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Minutes_TwoDigits_NoSeconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(0, 59, 0)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "exactly 59m"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Minutes_TwoDigits_NoSeconds_WithSeconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(0, 59, 30)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "59m30s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``SingleDigitHour_NoMinutes_NoSeconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(7, 0, 0)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "exactly 7h"
    Assert.Equal(expected, actual)

[<Fact>]
let ``SingleDigitHour_WithMinutes_NoSeconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(7, 20, 0)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "exactly 7h20m"
    Assert.Equal(expected, actual)

[<Fact>]
let ``SingleDigitHour_NoMinutes_WithSeconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(7, 0, 47)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "7h47s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``DoubleDigitHour_NoMinutes_NoSeconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(13, 0, 0)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "exactly 13h"
    Assert.Equal(expected, actual)

[<Fact>]
let ``SingleDigitHour_SingleDigitMinutes_NoSeconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(1, 5, 0)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "exactly 1h05m"
    Assert.Equal(expected, actual)

[<Fact>]
let ``SingleDigitHour_DoubleDigitMinutes_NoSeconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(1, 55, 0)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "exactly 1h55m"
    Assert.Equal(expected, actual)

[<Fact>]
let ``SingleDigitHour_DoubleDigitMinutes_SingleDigitSeconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(1, 55, 8)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "1h55m08s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``DoubleDigitHour_SingleDigitMinutes_SingleDigitSeconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(12, 5, 8)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "12h05m08s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``TripleDigitHour_SingleDigitMinutes_SingleDigitSeconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(36, 59, 59)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "36h59m59s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``SingleDigitDay_NoHoursMinutesOrSeconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(10, 0, 0, 0)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "exactly 240h"
    Assert.Equal(expected, actual)

[<Fact>]
let ``SingleDigitDay_WithHoursMinutesOrSeconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(4, 4, 59, 59)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "100h59m59s"
    Assert.Equal(expected, actual)

[<Fact>]
let ``TripleDigitDay_WithHoursMinutesOrSeconds_FormatsCorrectly`` () =
    let timeSpan = TimeSpan(100, 23, 59, 59)
    let actual = timeSpan.ElapsedFriendly()
    let expected = "2,423h59m59s"
    Assert.Equal(expected, actual)
