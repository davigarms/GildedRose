using System.Collections.Generic;
using System.Threading.Tasks;
using GildedRose.Lib;

namespace GildedRose.Console
{
    public class Program
    {
       public static async Task Main()
        {
            System.Console.WriteLine("OMGHAI!");
            await Initialise();
            System.Console.ReadKey();
        }

        private static async Task Initialise()
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
            store.UpdateQuality();
        }
    }
}
