namespace GildedRoseKata;

public static class ItemExtensions
{
    private const int MaxQuality = 50;

    public static void UpdateQuality(this Item item)
    {
        var sellInUpdater = SellInValueUpdaterFactory.Create(item.Name);
        item.SellIn = sellInUpdater.UpdateSellInValue(item.SellIn);
        UpdateQualityInternal(item);
    }

    private static void UpdateQualityInternal(Item item)
    {
        if (item.Name != GildedRose.AgedBrieName && item.Name != GildedRose.BackstagePassesName)
        {
            if (item.Quality > 0)
            {
                if (item.Name != GildedRose.SulfurasName)
                {
                    item.Quality -= 1;
                }
            }
        }
        else
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality += 1;

                if (item.Name == GildedRose.BackstagePassesName)
                {
                    if (item.SellIn < 10)
                    {
                        if (item.Quality < MaxQuality)
                        {
                            item.Quality += 1;
                        }
                    }

                    if (item.SellIn < 5)
                    {
                        if (item.Quality < MaxQuality)
                        {
                            item.Quality += 1;
                        }
                    }
                }
            }
        }

        if (item.SellIn < 0)
        {
            if (item.Name != GildedRose.AgedBrieName)
            {
                if (item.Name != GildedRose.BackstagePassesName)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != GildedRose.SulfurasName)
                        {
                            item.Quality -= 1;
                        }
                    }
                }
                else
                {
                    item.Quality = 0;
                }
            }
            else
            {
                if (item.Quality < MaxQuality)
                {
                    item.Quality += 1;
                }
            }
        }
    }
}