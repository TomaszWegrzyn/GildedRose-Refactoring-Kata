namespace GildedRoseKata;

public interface IQualityUpdateStrategy
{
    Quality Update(Quality currentQuality, int sellIn);

    static uint DefaultDegradeRate(int sellIn)
    {
        return (uint)(sellIn < 1 ? 2 : 1);
    }
}

public class Default : IQualityUpdateStrategy
{
    public Quality Update(Quality currentQuality, int sellIn)
    {
        return currentQuality - IQualityUpdateStrategy.DefaultDegradeRate(sellIn);
    }
}

public class Increase : IQualityUpdateStrategy
{
    public Quality Update(Quality currentQuality, int sellIn)
    {
        return currentQuality + IQualityUpdateStrategy.DefaultDegradeRate(sellIn);;
    }
}


public class Noop : IQualityUpdateStrategy
{
    public Quality Update(Quality currentQuality, int sellIn)
    {
        return currentQuality;
    }
}

public class BackStagePasses : IQualityUpdateStrategy
{
    public Quality Update(Quality currentQuality, int sellIn)
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

public class ConjuredQualityUpdateStrategy : IQualityUpdateStrategy
{
    public Quality Update(Quality currentQuality, int sellIn)
    {
        return currentQuality - 2 * IQualityUpdateStrategy.DefaultDegradeRate(sellIn);
    }
}

public static class QualityUpdateStrategyFactory
{
    public static IQualityUpdateStrategy Create(string itemName)
    {
        return itemName switch
        {
            GildedRose.AgedBrieName => new Increase(),
            GildedRose.SulfurasName => new Noop(),
            GildedRose.BackstagePassesName => new BackStagePasses(),
            GildedRose.ConjuredName => new ConjuredQualityUpdateStrategy(),
            _ => new Default()
        };
    }
}
