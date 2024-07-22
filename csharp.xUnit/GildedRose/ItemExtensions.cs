namespace GildedRoseKata;

public static class ItemExtensions
{
    public static void UpdateQuality(this Item item)
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
            if (item.Quality < 50)
            {
                item.Quality += 1;

                if (item.Name == GildedRose.BackstagePassesName)
                {
                    if (item.SellIn < 11)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }
                }
            }
        }

        if (item.Name != GildedRose.SulfurasName)
        {
            item.SellIn -= 1;
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
                    item.Quality -= item.Quality;
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }
        }
    }
}