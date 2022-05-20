using GildedRose.Lib;
using NUnit.Framework;

namespace GildedRose.Tests.StoreUpdateQualityTests
{
    [TestFixture]
    public class WhenProductIsBackstagePasses
    {
        private Store _store;

        [SetUp]
        public void Setup()
        {
            _store = new Store();
        }

        [TestCase(49, 50)]
        [TestCase(50, 50)]
        public void UpdateQuality_increase_the_quality_by_1_until_50_when_the_sellIn_date_is_greater_than_10(int quality, int expectedQuality)
        {
            _store.AddProduct("Backstage passes to a TAFKAL80ETC concert", 15, quality);
            _store.UpdateQuality();
            Assert.That(_store.GetProducts()[0].Quality, Is.EqualTo(expectedQuality));
        }

        [TestCase(10, 12)]
        [TestCase(48, 50)]
        [TestCase(49, 50)]
        [TestCase(50, 50)]
        public void UpdateQuality_increase_the_quality_value_by_2_until_50_when_the_sellIn_date_is_greater_than_5_and_less_than_11(int quality, int expectedQuality)
        {
            _store.AddProduct("Backstage passes to a TAFKAL80ETC concert", 10, quality);
            _store.UpdateQuality();
            Assert.That(_store.GetProducts()[0].Quality, Is.EqualTo(expectedQuality));
        }

        [TestCase(10, 13)]
        [TestCase(47, 50)]
        [TestCase(49, 50)]
        [TestCase(50, 50)]
        public void UpdateQuality_increase_the_quality_value_by_3_until_50_when_the_sellIn_date_is_5_or_less(int quality, int expectedQuality)
        {
            _store.AddProduct("Backstage passes to a TAFKAL80ETC concert", 5, quality);
            _store.UpdateQuality();
            Assert.That(_store.GetProducts()[0].Quality, Is.EqualTo(expectedQuality));
        }

        [TestCase(10, 0)]
        public void UpdateQuality_drop_the_the_quality_value_to_0_when_the_sellIn_date_has_passed(int quality, int expectedQuality)
        {
            _store.AddProduct("Backstage passes to a TAFKAL80ETC concert", 0, quality);
            _store.UpdateQuality();
            Assert.That(_store.GetProducts()[0].Quality, Is.EqualTo(expectedQuality));
        }
    }
}