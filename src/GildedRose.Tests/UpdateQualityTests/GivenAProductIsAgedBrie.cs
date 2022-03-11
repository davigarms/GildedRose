using NUnit.Framework;

namespace GildedRose.Tests.UpdateQualityTests
{
    [TestFixture]
    public class GivenAProductIsAgedBrie : GildedRoseTests
    {
        [TestCase(0, 1)]
        [TestCase(10, 11)]
        [TestCase(49, 50)]
        [TestCase(50, 50)]
        public void When_the_sellIn_date_has_not_passed_an_updated_should_increase_the_quality_by_1_until_50(int quality, int expectedQuality)
        {
            AddItems("Aged Brie", 1, quality);
            App.UpdateQuality();
            Assert.That(App.Items[0].Quality, Is.EqualTo(expectedQuality));
        }

        [TestCase(0, 2)]
        [TestCase(10, 12)]
        [TestCase(49, 50)]
        [TestCase(50, 50)]
        public void When_the_sellIn_date_has_passed_an_updated_should_increase_the_quality_by_2_until_50(int quality, int expectedQuality)
        {
            AddItems("Aged Brie", 0, quality);
            App.UpdateQuality();
            Assert.That(App.Items[0].Quality, Is.EqualTo(expectedQuality));
        }
    }
}