namespace GildedRoseKata;

public class ItemUpdater
{
    private const int LegendaryMaxQuality = 80;
    private const int DefaultMaxQuality = 50;
    
    private readonly Item _item;
    private readonly IQualityUpdateStrategy _qualityUpdateStrategy;

    private bool Legendary => _item.Name is GildedRose.SulfurasName; 
    
    private Quality Quality => new(_item.Quality, MaxQuality);

    private int MaxQuality => Legendary ? LegendaryMaxQuality : DefaultMaxQuality;

    public ItemUpdater(Item item)
    {
        _item = item;
        _qualityUpdateStrategy = QualityUpdateStrategyFactory.Create(_item.Name);
    }

    public void Update()
    {
        _item.Quality = (int)_qualityUpdateStrategy.Update(Quality, _item.SellIn);
        if (!Legendary)
        {
            _item.SellIn--;
        }
    }
}