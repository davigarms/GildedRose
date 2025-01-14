﻿using NUnit.Framework;

namespace GildedRose.Tests.UpdateQualityTests
{
    [TestFixture]
    public class GivenAProductIsSulfurus : GildedRoseTests
    {
        [TestCase(100, 100)]
        [TestCase(80, 80)]
        [TestCase(50, 50)]
        public void It_never_has_to_be_sold_and_it_never_decreases_in_quality(int quality, int expectedQuality)
        {
            _sut.AddProduct("Sulfuras, Hand of Ragnaros", 0, quality);
            _sut.UpdateQuality();
            Assert.That(_sut.Products[0].SellIn, Is.EqualTo(0));
            Assert.That(_sut.Products[0].Quality, Is.EqualTo(expectedQuality));
        }
    }
}