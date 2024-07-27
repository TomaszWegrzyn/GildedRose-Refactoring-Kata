using System;

namespace GildedRoseKata;

public interface IQualityValueUpdater
{
    Quality UpdateQualityValue(Quality currentQuality, int sellIn);

    static uint DefaultDegradeRate(int sellIn)
    {
        return (uint)(sellIn < 1 ? 2 : 1);
    }
}

public class DefaultQualityValueUpdater : IQualityValueUpdater
{
    public Quality UpdateQualityValue(Quality currentQuality, int sellIn)
    {
        return currentQuality - IQualityValueUpdater.DefaultDegradeRate(sellIn);
    }
}

public class IncreaseQualityUpdater : IQualityValueUpdater
{
    public Quality UpdateQualityValue(Quality currentQuality, int sellIn)
    {
        return currentQuality + IQualityValueUpdater.DefaultDegradeRate(sellIn);;
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
        return currentQuality - 2 * IQualityValueUpdater.DefaultDegradeRate(sellIn);
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
