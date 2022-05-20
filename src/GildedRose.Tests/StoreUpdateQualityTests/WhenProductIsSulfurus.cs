using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests.StoreUpdateQualityTests
{
    [TestFixture]
    public class WhenProductIsSulfurus
    {
        private Store _store;

        [SetUp]
        public void Setup()
        {
            _store = new Store();
        }
        
        [TestCase(100, 100)]
        [TestCase(80, 80)]
        [TestCase(50, 50)]
        public void UpdateQuality_never_decreases_sell_in_date_and_quality(int quality, int expectedQuality)
        {
            _store.AddProduct("Sulfuras, Hand of Ragnaros", 0, quality);
            _store.UpdateQuality();
            Assert.That(_store.GetProducts()[0].SellIn, Is.EqualTo(0));
            Assert.That(_store.GetProducts()[0].Quality, Is.EqualTo(expectedQuality));
        }
    }
}