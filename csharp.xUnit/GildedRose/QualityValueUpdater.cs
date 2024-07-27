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
        var decreaseBy = sellIn < 1 ? 2 : 1;
        return currentQuality - (uint)decreaseBy;
    }
}

public class IncreaseQualityUpdater : IQualityValueUpdater
{
    public Quality UpdateQualityValue(Quality currentQuality, int sellIn)
    {
        // duplicate - how to remove it?
        var increaseBy = sellIn < 1 ? 2 : 1;
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
            < 1 => currentQuality.ResetToZero(),
            < 6 => currentQuality + 3,
            < 11 => currentQuality + 2,
            _ => currentQuality + 1
        };
    }
}

public class ConjuredQualityValueUpdater : IQualityValueUpdater
{
    public Quality UpdateQualityValue(Quality currentQuality, int sellIn)
    {
        // duplicate - how to remove it?
        var decreaseBy = sellIn < 1 ? 4 : 2;
        return currentQuality - (uint)decreaseBy;
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
            GildedRose.ConjuredName => new ConjuredQualityValueUpdater(),
            _ => new DefaultQualityValueUpdater()
        };
    }
}
