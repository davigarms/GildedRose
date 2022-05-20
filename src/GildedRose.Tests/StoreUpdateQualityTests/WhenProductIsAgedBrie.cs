using GildedRose.Lib;
using NUnit.Framework;

namespace GildedRose.Tests.StoreUpdateQualityTests
{
    [TestFixture]
    public class WhenProductIsAgedBrie
    {
        private Store _store;

        [SetUp]
        public void Setup()
        {
            _store = new Store();
        }
        
        [TestCase(0, 1)]
        [TestCase(10, 11)]
        [TestCase(49, 50)]
        [TestCase(50, 50)]
        public void UpdateQuality_increase_the_quality_by_1_until_50_when_the_sellIn_date_has_not_passed(int quality, int expectedQuality)
        {
            _store.AddProduct("Aged Brie", 1, quality);
            _store.UpdateQuality();
            Assert.That(_store.GetProducts()[0].Quality, Is.EqualTo(expectedQuality));
        }

        [TestCase(0, 2)]
        [TestCase(10, 12)]
        [TestCase(49, 50)]
        [TestCase(50, 50)]
        public void UpdateQuality_increase_the_quality_by_2_until_50_when_the_sellIn_date_has_passed(int quality, int expectedQuality)
        {
            _store.AddProduct("Aged Brie", 0, quality);
            _store.UpdateQuality();
            Assert.That(_store.GetProducts()[0].Quality, Is.EqualTo(expectedQuality));
        }
    }
}