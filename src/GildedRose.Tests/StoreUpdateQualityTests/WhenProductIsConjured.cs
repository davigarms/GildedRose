using GildedRose.Lib;
using NUnit.Framework;

namespace GildedRose.Tests.StoreUpdateQualityTests
{
    [TestFixture]
    public class WhenProductIsConjured
    {
        private Store _store;

        [SetUp]
        public void Setup()
        {
            _store = new Store();
        }

        [TestCase(10, 8)]
        [TestCase(5, 3)]
        [TestCase(1, 0)]
        [TestCase(0, 0)]
        public void UpdateQuality_decrease_the_quality_by_2_until_0_when_the_sellIn_date_has_not_passed(int quality, int expectedQuality)
        {
            _store.AddProduct("Conjured", 1, quality);
            _store.UpdateQuality();
            Assert.That(_store.GetProducts()[0].Quality, Is.EqualTo(expectedQuality));
        }
        
        [TestCase(10, 6)]
        [TestCase(5, 1)]
        [TestCase(1, 0)]
        [TestCase(0, 0)]
        public void UpdateQuality_decrease_the_quality_by_4_until_0_when_the_sellIn_date_has_passed(int quality, int expectedQuality)
        {
            _store.AddProduct("Conjured", 0, quality);
            _store.UpdateQuality();
            Assert.That(_store.GetProducts()[0].Quality, Is.EqualTo(expectedQuality));
        }
    }
}