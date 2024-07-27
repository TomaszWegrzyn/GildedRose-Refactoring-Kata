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
        if (sellIn < 0)
        {
            return currentQuality.ResetToZero();
        }
        
        if(sellIn < 5)
        {
            return currentQuality + 3;
        }

        if (sellIn < 10)
        {
            return currentQuality + 2;
        }

        return currentQuality + 1;
    }
}

public static class QualityValueUpdaterFactory
{
    public static IQualityValueUpdater Create(string itemName)
    {
        return itemName switch
        {
            GildedRose.AgedBrieName => new IncreaseQualityUpdater(),
            GildedRose.SulfurasName => new NoopQualityUpdater(),
            GildedRose.BackstagePassesName => new BackStagePassesQualityUpdater(),
            _ => new DefaultQualityValueUpdater()
        };
    }
}
