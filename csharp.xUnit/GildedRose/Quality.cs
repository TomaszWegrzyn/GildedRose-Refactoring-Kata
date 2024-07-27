using System;

namespace GildedRoseKata;

public class Quality
{
    private readonly int _currentValue;
    private readonly int _maxValue;

    public Quality(int currentValue, int maxValue)
    {
        if (currentValue < 0)
        {
            throw new ArgumentException("Quality cannot be negative", nameof(currentValue));
        }

        if (maxValue < 1)
        {
            throw new ArgumentException("Quality max value must be positive", nameof(maxValue));
        }

        if (currentValue > maxValue)
        {
            throw new ArgumentException("Quality value cannot be above max value");
        }
        _currentValue = currentValue;
        _maxValue = maxValue;
    }

    public Quality DecreaseBy(uint value)
    {
        // maybe catch overflow exceptions?
        var potentialResult = _currentValue - (int)value;
        var newValue = Math.Max(potentialResult, 0);
        return new Quality(newValue, _maxValue);
    }
    
    public Quality IncreaseBy(uint value)
    {
        // maybe catch overflow exceptions?
        var potentialResult = _currentValue + (int)value;
        var newValue = Math.Min(potentialResult, _maxValue);
        return new Quality(newValue, _maxValue);

    }
    
    public Quality ResetToZero()
    {
        return new Quality(0, _maxValue);
    }

    public static Quality operator +(Quality quality, uint value)
    {
        return quality.IncreaseBy(value);
    }
    
    public static Quality operator -(Quality quality, uint value)
    {
        return quality.DecreaseBy(value);
    }
    
    public static bool operator ==(Quality quality, uint value)
    {
        return quality._currentValue == value;
    }
    
    public static bool operator !=(Quality quality, uint value)
    {
       return quality._currentValue != value;
    }

    public static explicit operator int(Quality quality)
    {
        return quality._currentValue;
    }
}