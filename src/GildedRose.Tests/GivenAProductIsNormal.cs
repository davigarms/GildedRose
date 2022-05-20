using NUnit.Framework;

namespace GildedRose.Tests.UpdateQualityTests
{
    [TestFixture]
    public class GivenAProductIsNormal : GildedRoseTests
    {
        [TestCase(20, 19)]
        [TestCase(10, 9)]
        [TestCase(0, -1)]
        public void An_updated_should_decrease_the_sellIn_date_by_1(int sellIn, int expectedSellIn)
        {
            _sut.AddProduct("product", sellIn, 0);
            _sut.UpdateQuality();
            Assert.That(_sut.Products[0].SellIn, Is.EqualTo(expectedSellIn));
        }

        [TestCase(10, 9)]
        [TestCase(5, 4)]
        [TestCase(1, 0)]
        [TestCase(0, 0)]
        public void When_the_sellIn_date_has_not_passed_an_updated_should_decrease_the_quality_by_1_until_0(int quality, int expectedQuality)
        {
            _sut.AddProduct("product", 1, quality);
            _sut.UpdateQuality();
            Assert.That(_sut.Products[0].Quality, Is.EqualTo(expectedQuality));
        }

        [TestCase(10, 8)]
        [TestCase(5, 3)]
        [TestCase(1, 0)]
        [TestCase(0, 0)]
        public void When_the_sellIn_date_has_passed_an_updated_should_decrease_the_quality_by_2_until_0(int quality, int expectedQuality)
        {
            _sut.AddProduct("product", 0, quality);
            _sut.UpdateQuality();
            Assert.That(_sut.Products[0].Quality, Is.EqualTo(expectedQuality));
        }
    }
}