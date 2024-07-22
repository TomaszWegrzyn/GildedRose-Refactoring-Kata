using System;

namespace GildedRoseKata;

public interface IQualityValueUpdater
{
    Quality UpdateQualityValue(Quality currentQuality, int sellIn);
}

public class DefaultQualityValueUpdater : IQualityValueUpdater
{
    public Quality UpdateQualityValue(Quality currentQuality, int sellIn)
    {
        // duplicate - how to remove it?
        var decreaseBy = sellIn < 0 ? 2 : 1;
        return currentQuality - (uint)decreaseBy;
    }
}

public class IncreaseQualityUpdater : IQualityValueUpdater
{
    public Quality UpdateQualityValue(Quality currentQuality, int sellIn)
    {
        // duplicate - how to remove it?
        var increaseBy = sellIn < 0 ? 2 : 1;
        return currentQuality + (uint)increaseBy;
    }
}


public class NoopQualityUpdater : IQualityValueUpdater
{
    public Quality UpdateQualityValue(Quality currentQuality, int sellIn)
    {
        return currentQuality;
    }
}

public class BackStagePassesQualityUpdater : IQualityValueUpdater
{
    public Quality UpdateQualityValue(Quality currentQuality, int sellIn)
    {
        return sellIn switch
        {
            < 0 => currentQuality.ResetToZero()
            < 
        };
    }
}

public static class QualityValueUpdaterFactory
{
    public static IQualityValueUpdater Create(string itemName)
    {
        throw new NotImplementedException();
    }
}
