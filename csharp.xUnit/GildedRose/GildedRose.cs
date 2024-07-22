using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    public const string AgedBrieName = "Aged Brie";
    public const string SulfurasName = "Sulfuras, Hand of Ragnaros";
    public const string BackstagePassesName = "Backstage passes to a TAFKAL80ETC concert";

    // DO NOT CHANGE THIS property
    // ReSharper disable all
    IList<Item> Items;
    // ReSharper restore all


    // ReSharper disable once ConvertToPrimaryConstructor 
    // not sure if it is allowed in this kata, also not a fan of primary constructors,
    // because of lack of readonly support
    public GildedRose(IList<Item> items)
    {
        Items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            if (item.Name != AgedBrieName && item.Name != BackstagePassesName)
            {
                if (item.Quality > 0)
                {
                    if (item.Name != SulfurasName)
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

                    if (item.Name == BackstagePassesName)
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

            if (item.Name != SulfurasName)
            {
                item.SellIn -= 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != AgedBrieName)
                {
                    if (item.Name != BackstagePassesName)
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != SulfurasName)
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
}