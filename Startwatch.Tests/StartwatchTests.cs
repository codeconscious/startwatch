using System;
using Startwatch.Library;

namespace Startwatch.Tests;

public sealed class StartwatchTests
{
    [Fact]
    public void Milliseconds_OneDigit_FormatsCorrectly()
    {
        TimeSpan timeSpan = TimeSpan.FromMilliseconds(1);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "1ms";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Milliseconds_TwoDigits_FormatsCorrectly()
    {
        TimeSpan timeSpan = TimeSpan.FromMilliseconds(99);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "99ms";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Milliseconds_ThreeDigits_FormatsCorrectly()
    {
        TimeSpan timeSpan = TimeSpan.FromMilliseconds(999);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "999ms";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Milliseconds_ThreeDigitsWithSmallDecimal_FormatsCorrectly()
    {
        TimeSpan timeSpan = TimeSpan.FromMilliseconds(999.3);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "999ms";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Milliseconds_ThreeDigitsWithLargeDecimal_FormatsCorrectly()
    {
        TimeSpan timeSpan = TimeSpan.FromMilliseconds(999.9);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "1000ms";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SecondsOnly_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(0, 0, 3);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "3.00s";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Seconds_With500Milliseconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(0, 0, 0, 3, 500);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "3.50s";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Seconds_With520Milliseconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(0, 0, 0, 3, 520);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "3.52s";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Minute_NoSeconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(0, 1, 0);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "exactly 1m";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Minute_30Seconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(0, 1, 30);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "1m30s";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Minutes_TwoDigits_NoSeconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(0, 59, 0);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "exactly 59m";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Minutes_TwoDigits_NoSeconds_WithSeconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(0, 59, 30);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "59m30s";
        Assert.Equal(expected, actual);
    }


    [Fact]
    public void SingleDigitHour_NoMinutes_NoSeconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(7, 0, 0);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "exactly 7h";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SingleDigitHour_WithMinutes_NoSeconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(7, 20, 0);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "exactly 7h20m";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SingleDigitHour_NoMinutes_WithSeconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(7, 0, 47);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "7h47s";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DoubleDigitHour_NoMinutes_NoSeconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(13, 0, 0);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "exactly 13h";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SingleDigitHour_SingleDigitMinutes_NoSeconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(1, 5, 0);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "exactly 1h05m";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SingleDigitHour_DoubleDigitMinutes_NoSeconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(1, 55, 0);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "exactly 1h55m";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SingleDigitHour_DoubleDigitMinutes_SingleDigitSeconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(1, 55, 8);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "1h55m08s";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DoubleDigitHour_SingleDigitMinutes_SingleDigitSeconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(12, 5, 8);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "12h05m08s";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TripleDigitHour_SingleDigitMinutes_SingleDigitSeconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(36, 59, 59);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "36h59m59s";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SingleDigitDay_NoHoursMinutesOrSeconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(10, 0, 0, 0);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "exactly 240h";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SingleDigitDay_WithHoursMinutesOrSeconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(4, 4, 59, 59);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "100h59m59s";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TripleDigitDay_WithHoursMinutesOrSeconds_FormatsCorrectly()
    {
        TimeSpan timeSpan = new(100, 23, 59, 59);
        string actual = timeSpan.ElapsedFriendly();
        string expected = "2,423h59m59s";
        Assert.Equal(expected, actual);
    }
}
