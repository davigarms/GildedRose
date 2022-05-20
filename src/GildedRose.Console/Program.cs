using System.Collections.Generic;
using System.Threading.Tasks;
using GildedRose.Lib;

namespace GildedRose.Console
{
    public static class Program
    {
        private static void Main()
        {
            Initialise();
        }

       private static void Initialise()
        {
            var products = new List<Product>
            {
                new Product { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Product { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Product { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Product { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Product
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Product { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
            };
            
            var store = new Store(products);
            System.Console.WriteLine("OMGHAI!");
            store.UpdateQuality();
            store.DisplayProducts();
        }
    }
}
