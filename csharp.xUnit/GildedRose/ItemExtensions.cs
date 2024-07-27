namespace GildedRoseKata;

public static class ItemExtensions
{
    public static void UpdateQuality(this Item item)
    {
        var sellInUpdater = SellInValueUpdaterFactory.Create(item.Name);
        var qualityValueUpdater = QualityValueUpdaterFactory.Create(item.Name);
        item.Quality = (int)qualityValueUpdater.UpdateQualityValue(item.GetQuality(), item.SellIn);
        item.SellIn = sellInUpdater.UpdateSellInValue(item.SellIn);
    }

    private static Quality GetQuality(this Item item)
    {
        var maxValue = item.Name == GildedRose.SulfurasName ? 80 : 50;
        return new Quality(item.Quality, maxValue);
    }
}