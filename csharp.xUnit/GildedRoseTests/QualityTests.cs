using System;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class QualityTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(44)]
    [InlineData(111)]
    [InlineData(123)]
    [InlineData(1233)]
    [InlineData(99999)]
    [InlineData(int.MaxValue)]
    public void CanCreateQualityWithPositiveOr0Value(int value)
    {
        _ = new Quality(value, int.MaxValue);
    }
    
    [Theory]
    [InlineData(0, 1)]
    [InlineData(2, 3)]
    [InlineData(3, 6)]
    [InlineData(44, 66)]
    [InlineData(111, 188)]
    [InlineData(123, 999)]
    [InlineData(1233, 6666)]
    [InlineData(99999, 99999)]
    [InlineData(int.MaxValue, int.MaxValue)]
    public void CanCreateQualityWithPositiveOr0ValueAndPositiveMaxValue(int value, int maxValue)
    {
        _ = new Quality(value, maxValue);
    }
    
    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-3)]
    [InlineData(-44)]
    [InlineData(-111)]
    [InlineData(-123)]
    [InlineData(-1233)]
    [InlineData(-99999)]
    [InlineData(int.MinValue)]
    public void QualityValueMustNotBeNegative(int value)
    {
        Assert.Throws<ArgumentException>(() => _ = new Quality(value, int.MaxValue));
    }
    
    [Theory]
    [InlineData(1, 0)]
    [InlineData(2, -1)]
    [InlineData(3, -3)]
    [InlineData(44, -234)]
    [InlineData(111, -2342)]
    [InlineData(123, -90000)]
    [InlineData(1233, -100000)]
    [InlineData(99999, int.MinValue)]
    public void QualityMaxValueMustBePositive(int value, int maxValue)
    {
        Assert.Throws<ArgumentException>(() => _ = new Quality(value, maxValue));
    }
    
    [Theory]
    [InlineData(21, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(44, 34)]
    [InlineData(111, 42)]
    [InlineData(1001, 1000)]
    [InlineData(1233, 1000)]
    [InlineData(int.MaxValue, int.MaxValue - 1)]
    public void CanNotCreateQualityWithValueAboveMaxValue(int value, int maxValue)
    {
        Assert.Throws<ArgumentException>(() => _ = new Quality(value, maxValue));
    }

    [Fact]
    public void QualityHasExplicitConversionToInt()
    {
        var quality = new Quality(11, 50);
        _ = (int) quality;
    }
}