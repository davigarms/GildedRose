using GildedRose.Lib;
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
        
        [TestCase(100, 100, 10)]
        [TestCase(80, 80, 5)]
        [TestCase(50, 50, 0)]
        public void UpdateQuality_never_decreases_sell_in_date_and_quality(int quality, int expectedQuality, int sellInt)
        {
            _store.AddProduct("Sulfuras, Hand of Ragnaros", sellInt, quality);
            _store.UpdateQuality();
            Assert.That(_store.GetProducts()[0].SellIn, Is.EqualTo(sellInt));
            Assert.That(_store.GetProducts()[0].Quality, Is.EqualTo(expectedQuality));
        }
    }
}