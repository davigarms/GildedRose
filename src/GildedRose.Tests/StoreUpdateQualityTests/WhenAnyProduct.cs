using GildedRose.Lib;
using NUnit.Framework;

namespace GildedRose.Tests.StoreUpdateQualityTests
{
    [TestFixture]
    public class WhenAnyProduct
    {
        private Store _store;

        [SetUp]
        public void Setup()
        {
            _store = new Store();
        }
        
        [TestCase(20, 19)]
        [TestCase(10, 9)]
        [TestCase(0, -1)]
        public void UpdateQuality_should_decrease_the_sellIn_date_by_1(int sellIn, int expectedSellIn)
        {
            _store.AddProduct("product", sellIn, 0);
            _store.UpdateQuality();
            Assert.That(_store.GetProducts()[0].SellIn, Is.EqualTo(expectedSellIn));
        }
    }
}