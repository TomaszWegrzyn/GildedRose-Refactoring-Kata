namespace GildedRoseKata;

public interface ISellInValueUpdater
{
    int UpdateSellInValue(int current);
}

public class DefaultSellInInValueUpdater : ISellInValueUpdater
{
    public int UpdateSellInValue(int current)
    {
        return --current;
    }
}

public class NoopSellInInValueUpdater : ISellInValueUpdater
{
    public int UpdateSellInValue(int current)
    {
        return current;
    }
}

public static class SellInValueUpdaterFactory
{
    public static ISellInValueUpdater Create(string itemName)
    {
        if (itemName is GildedRose.SulfurasName)
        {
            return new NoopSellInInValueUpdater();
        }

        return new DefaultSellInInValueUpdater();
    }
}
