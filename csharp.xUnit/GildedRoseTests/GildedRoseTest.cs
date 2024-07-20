using Xunit;
using System.Collections.Generic;
using System.Linq;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact(Skip = "building my own suite of tests. skipped temporarily")]
    public void foo()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
    }

    [Theory]
    [InlineData(-224)]
    [InlineData(-212)]
    [InlineData(-22)]
    [InlineData(-14)]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(12)]
    [InlineData(22)]
    [InlineData(55522)]
    public void SulfurasDoesNotDecreaseInQuality(int sellIn)
    {
        var sulfuras = CreateSulfuras(sellIn);
        var items = UpdateQuality(sulfuras);

        Assert.Equal(80, items.First().Quality);
    }

    [Theory]
    [InlineData(-213244)]
    [InlineData(-2124)]
    [InlineData(-714)]
    [InlineData(-214)]
    [InlineData(-4)]
    [InlineData(-2)]
    [InlineData(-1)]
    [InlineData(-0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(66)]
    [InlineData(324)]
    [InlineData(234234)]
    [InlineData(2342342)]
    public void SulfurasSellInValueNeverChanges(int sellIn)
    {
        var sulfuras = CreateSulfuras(sellIn);
        var items = UpdateQuality(sulfuras);

        Assert.Equal(sellIn, items.First().SellIn);
    }


    [Theory]
    [InlineData(0, 2)]
    [InlineData(1, 3)]
    [InlineData(2, 4)]
    [InlineData(3, 5)]
    [InlineData(10, 4)]
    [InlineData(14, 4)]
    [InlineData(22, 5)]
    [InlineData(25, 66)]
    [InlineData(44, 324)]
    [InlineData(45, 234234)]
    [InlineData(47, 2342342)]
    [InlineData(49, 234234)]
    [InlineData(49, 2342342)]
    public void AgedBrieIncreasesInQualityByOneUpTo50WhenSellInAboveZero(int quality, int sellIn)
    {
        var agedBrie = CreateAgedBrie(quality, sellIn);
        var items = UpdateQuality(agedBrie);

        var expectedQuality = quality + 1;
        Assert.Equal(expectedQuality, items.First().Quality);
    }
    
    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, -1)]
    [InlineData(0, -2)]
    [InlineData(1, -3)]
    [InlineData(2, -4)]
    [InlineData(3, -5)]
    [InlineData(10, -4)]
    [InlineData(14, -4)]
    [InlineData(22, -5)]
    [InlineData(25, -66)]
    [InlineData(44, -324)]
    [InlineData(45, -234234)]
    [InlineData(47, -2342342)]
    [InlineData(48, -234234)]
    [InlineData(48, -11)]
    public void AgedBrieIncreasesInQualityByTwoUpTo50WhenSellInZeroOrLess(int quality, int sellIn)
    {
        var agedBrie = CreateAgedBrie(quality, sellIn);
        var items = UpdateQuality(agedBrie);
        var expectedQuality = quality + 2;
        Assert.Equal(expectedQuality, items.First().Quality);
    }

    [Theory]
    [InlineData(0, -55555)]
    [InlineData(0, 0)]
    [InlineData(1, -55555)]
    [InlineData(1, -24234)]
    [InlineData(1, 0)]
    [InlineData(2, -24234)]
    [InlineData(2, -1)]
    [InlineData(2, 0)]
    [InlineData(3, -24234)]
    [InlineData(3, 0)]
    [InlineData(4, -24234)]
    [InlineData(4, -1)]
    [InlineData(4, 0)]
    [InlineData(15, -1)]
    [InlineData(15, 0)]
    [InlineData(20, -24234)]
    [InlineData(22, -24234)]
    [InlineData(23, -24234)]
    [InlineData(25, -24234)]
    [InlineData(50, -24234)]
    public void BackstagePassesQualityIsResetToZeroWhenSellInZeroOrLess(int quality, int sellIn)
    {
        var backstagePasses = CreateBackstagePasses(quality, sellIn);
        var items = UpdateQuality(backstagePasses);

        Assert.Equal(0, items.First().Quality);
    }

    [Theory]
    [InlineData(0, 11)]
    [InlineData(0, 20)]
    [InlineData(1, 11)]
    [InlineData(1, 12)]
    [InlineData(1, 111)]
    [InlineData(2, 11)]
    [InlineData(2, 111)]
    [InlineData(2, 11150)]
    [InlineData(3, 11)]
    [InlineData(3, 44)]
    [InlineData(4, 11)]
    [InlineData(4, 21)]
    [InlineData(4, 30)]
    [InlineData(15, 11)]
    [InlineData(15, 120)]
    [InlineData(20, 11)]
    [InlineData(22, 34)]
    [InlineData(23, 11)]
    [InlineData(25, 11)]
    [InlineData(47, 11)]
    [InlineData(47, 12)]
    [InlineData(47, 13)]
    [InlineData(48, 11)]
    [InlineData(48, 15)]
    [InlineData(49, 11)]
    public void BackstagePassesIncreasesInQualityByOneUpTo50WhenSellInAbove10(int quality, int sellIn)
    {
        var backstagePasses = CreateBackstagePasses(quality, sellIn);
            
        var items = UpdateQuality(backstagePasses);

        Assert.Equal(quality + 1, items.First().Quality);
    }

    private static Item CreateBackstagePasses(int quality, int sellIn)
    {
        var backstagePasses = new Item()
        {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            Quality = quality,
            SellIn = sellIn,
        };
        return backstagePasses;
    }


    private static IList<Item> UpdateQuality(Item item)
    {
        IList<Item> items = [item];
        var sut = new GildedRose(items);
        sut.UpdateQuality();
        return items;
    }

    private static Item CreateAgedBrie(int quality, int sellIn)
    {
        var agedBrie = new Item()
        {
            Name = "Aged Brie",
            Quality = quality,
            SellIn = sellIn,
        };
        return agedBrie;
    }
    private static Item CreateSulfuras(int sellIn)
    {
        var sulfuras = new Item()
        {
            Name = "Sulfuras, Hand of Ragnaros",
            Quality = 80,
            SellIn = sellIn
        };
        return sulfuras;
    }
}
