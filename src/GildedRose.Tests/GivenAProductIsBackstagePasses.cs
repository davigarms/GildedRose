using NUnit.Framework;

namespace GildedRose.Tests.UpdateQualityTests
{
    [TestFixture]
    public class GivenAProductIsBackstagePasses : GildedRoseTests
    {
        [TestCase(49, 50)]
        [TestCase(50, 50)]
        public void When_the_sellIn_date_is_greater_than_10_an_updated_should_increase_the_quality_by_1_until_50(int quality, int expectedQuality)
        {
            _sut.AddProduct("Backstage passes to a TAFKAL80ETC concert", 15, quality);
            _sut.UpdateQuality();
            Assert.That(_sut.Products[0].Quality, Is.EqualTo(expectedQuality));
        }

        [TestCase(10, 12)]
        [TestCase(48, 50)]
        [TestCase(49, 50)]
        [TestCase(50, 50)]
        public void
            When_the_sellIn_date_is_greater_than_5_and_less_than_11_an_updated_should_increase_the_quality_value_by_2_until_50(int quality, int expectedQuality)
        {
            _sut.AddProduct("Backstage passes to a TAFKAL80ETC concert", 10, quality);
            _sut.UpdateQuality();
            Assert.That(_sut.Products[0].Quality, Is.EqualTo(expectedQuality));
        }

        [TestCase(10, 13)]
        [TestCase(47, 50)]
        [TestCase(49, 50)]
        [TestCase(50, 50)]
        public void When_the_sellIn_date_is_5_or_less_an_updated_should_increase_the_quality_value_by_3_until_50(int quality, int expectedQuality)
        {
            _sut.AddProduct("Backstage passes to a TAFKAL80ETC concert", 5, quality);
            _sut.UpdateQuality();
            Assert.That(_sut.Products[0].Quality, Is.EqualTo(expectedQuality));
        }

        [TestCase(10, 0)]
        public void When_the_sellIn_date_has_passed_an_updated_should_drop_the_the_quality_value_to_0(int quality, int expectedQuality)
        {
            _sut.AddProduct("Backstage passes to a TAFKAL80ETC concert", 0, quality);
            _sut.UpdateQuality();
            Assert.That(_sut.Products[0].Quality, Is.EqualTo(expectedQuality));
        }
    }
}