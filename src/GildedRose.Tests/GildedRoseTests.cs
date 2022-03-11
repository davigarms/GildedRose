using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class GildedRoseTests
    {
        protected Program App;

        [SetUp]
        public void Setup()
        {
            App = new Program
            {
                Items = new List<Item>()
            };
        }

        protected void AddItems(string name, int sellIn, int quality)
        {
            App.Items.Add(
                new Item
                {
                    Name = name,
                    SellIn = sellIn,
                    Quality = quality
                }
            );
        }
    }
}