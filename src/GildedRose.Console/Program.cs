using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;

        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

                          };

            app.UpdateQuality();
          
            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                DecreaseSellInDate(item);
                UpdateNormalProductsQuality(item);
                UpdateAgedBrieQuality(item);
                UpdateBackStagePassesQuality(item);
            }
        }

        private void UpdateNormalProductsQuality(Item item)
        {
            if (SulfurasHandOfRagnaros(item) || BackstagePasses(item) || AgedBrie(item)) return;
            DecreaseQualityWhenGreaterThanZero(item);
            if (SellInDateLessThanZero(item))
                DecreaseQualityWhenGreaterThanZero(item);
        }

        private void UpdateAgedBrieQuality(Item item)
        {
            if (!AgedBrie(item)) return;
            IncreaseQualityWhenLessThanFifty(item);
            if (SellInDateLessThanZero(item))
                IncreaseQualityWhenLessThanFifty(item);
        }
        
        private void UpdateBackStagePassesQuality(Item item)
        {
            if (!BackstagePasses(item)) return;
            IncreaseQualityWhenLessThanFifty(item);
            IncreaseQualityWhenCloserToAConcertDate(item);
            if (SellInDateLessThanZero(item))
                DropQualityToZero(item);
        }

        private void IncreaseQualityWhenCloserToAConcertDate(Item item)
        {
            if (!BackstagePasses(item)) return;
            if (item.SellIn < 11)
                IncreaseQualityWhenLessThanFifty(item);

            if (item.SellIn < 6)
                IncreaseQualityWhenLessThanFifty(item);
        }

        private void DropQualityToZero(Item item)
        {
            item.Quality -= item.Quality;
        }

        private void DecreaseSellInDate(Item item)
        {
            if (!SulfurasHandOfRagnaros(item))
                item.SellIn -= 1;
        }

        private void IncreaseQualityWhenLessThanFifty(Item item)
        {
            if (QualityLessThanFifty(item))
                IncreaseQuality(item);
        }
        
        private void DecreaseQualityWhenGreaterThanZero(Item item)
        {
            if (QualityGreaterThanZero(item))
                DecreaseQuality(item);
        }
        
        private void IncreaseQuality(Item item)
        {
            item.Quality += 1;
        }

        private void DecreaseQuality(Item item)
        {
            item.Quality -= 1;
        }

        private bool SulfurasHandOfRagnaros(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private bool BackstagePasses(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool AgedBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private bool QualityLessThanFifty(Item item)
        {
            return item.Quality < 50;
        }
        private bool QualityGreaterThanZero(Item item)
        {
            return item.Quality > 0;
        }

        private bool SellInDateLessThanZero(Item item)
        {
            return item.SellIn < 0;
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}
