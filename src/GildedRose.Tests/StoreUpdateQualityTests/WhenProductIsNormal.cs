using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests.StoreUpdateQualityTests
{
    [TestFixture]
    public class WhenProductIsNormal
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

        [TestCase(10, 9)]
        [TestCase(5, 4)]
        [TestCase(1, 0)]
        [TestCase(0, 0)]
        public void UpdateQuality_should_decrease_the_quality_by_1_until_0_when_the_sellIn_date_has_not_passed(int quality, int expectedQuality)
        {
            _store.AddProduct("product", 1, quality);
            _store.UpdateQuality();
            Assert.That(_store.GetProducts()[0].Quality, Is.EqualTo(expectedQuality));
        }

        [TestCase(10, 8)]
        [TestCase(5, 3)]
        [TestCase(1, 0)]
        [TestCase(0, 0)]
        public void UpdateQuality_should_decrease_the_quality_by_2_until_0_when_the_sellIn_date_has_passed(int quality, int expectedQuality)
        {
            _store.AddProduct("product", 0, quality);
            _store.UpdateQuality();
            Assert.That(_store.GetProducts()[0].Quality, Is.EqualTo(expectedQuality));
        }
    }
}