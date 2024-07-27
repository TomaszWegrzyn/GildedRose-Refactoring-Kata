using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

public class GildedRose
{
    public const string AgedBrieName = "Aged Brie";
    public const string SulfurasName = "Sulfuras, Hand of Ragnaros";
    public const string BackstagePassesName = "Backstage passes to a TAFKAL80ETC concert";
    public const string ConjuredName = "Conjured";

    
    // DO NOT CHANGE THIS property
    // ReSharper disable all
    IList<Item> Items;

    private readonly IReadOnlyCollection<ItemUpdater> _itemUpdaters;
    // ReSharper restore all


    // ReSharper disable once ConvertToPrimaryConstructor 
    // not sure if it is allowed in this kata, also not a fan of primary constructors,
    // because of lack of readonly support
    public GildedRose(IList<Item> items)
    {
        Items = items;
        _itemUpdaters = items.Select(CreateItemUpdater).ToList();
    }
    
    private static ItemUpdater CreateItemUpdater(Item item)
    {
        return new ItemUpdater(item);
    }


    public void UpdateQuality()
    {
        foreach (var itemUpdater in _itemUpdaters)
        {
            itemUpdater.Update();
        }
    }
}