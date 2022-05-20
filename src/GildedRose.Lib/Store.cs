using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Lib
{
    public class Store
    {
        private readonly List<Product> _products;

        public Store(List<Product> products = null)
        {
            _products = products ?? new List<Product>();
        }

        public void AddProduct(string name, int sellIn, int quality)
        {
            _products.Add(new Product
            {
                Name = name,
                SellIn = sellIn,
                Quality = quality
            });
        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public IList<Product> GetProducts()
        {
            return _products;
        }

        public void UpdateQuality()
        {
            foreach (var item in _products)
            {
                DecreaseSellInDate(item);
                UpdateNormalProductsQuality(item);
                UpdateConjuredProductsQuality(item);
                UpdateAgedBrieQuality(item);
                UpdateBackStagePassesQuality(item);
            }
        }

        private static void UpdateNormalProductsQuality(Product product)
        {
            if (Normal(product)) return;
            DecreaseQualityWhenGreaterThanZero(product, SellInDateLessThanZero(product) ? 2 : 1);
        }

       
        private static void UpdateConjuredProductsQuality(Product product)
        {
            if (!Conjured(product)) return;
            DecreaseQualityWhenGreaterThanZero(product, SellInDateLessThanZero(product) ? 4 : 2);
        }

        private static void UpdateAgedBrieQuality(Product product)
        {
            if (!AgedBrie(product)) return;
            IncreaseQualityWhenLessThanFifty(product, SellInDateLessThanZero(product) ? 2 : 1);
        }

        private static void UpdateBackStagePassesQuality(Product product)
        {
            if (!BackstagePasses(product)) return;
            IncreaseQualityWhenLessThanFifty(product);
            IncreaseQualityWhenCloserToAConcertDate(product);
            if (SellInDateLessThanZero(product))
                DropQualityToZero(product);
        }

        private static void IncreaseQualityWhenCloserToAConcertDate(Product product)
        {
            if (!BackstagePasses(product)) return;
            if (product.SellIn < 11)
                IncreaseQualityWhenLessThanFifty(product);

            if (product.SellIn < 6)
                IncreaseQualityWhenLessThanFifty(product);
        }

        private static void DropQualityToZero(Product product)
        {
            product.Quality -= product.Quality;
        }

        private static void DecreaseSellInDate(Product product)
        {
            if (!SulfurasHandOfRagnaros(product))
                product.SellIn -= 1;
        }

        private static void IncreaseQualityWhenLessThanFifty(Product product, int days = 1)
        {
            for (var i = 0; i < days; i++)
            {
                if (QualityLessThanFifty(product))
                    IncreaseQualityByOne(product);
            }
        }

        private static void DecreaseQualityWhenGreaterThanZero(Product product, int days = 1)
        {
            for (var i = 0; i < days; i++)
            {
                if (QualityGreaterThanZero(product))
                    DecreaseQualityByOne(product);
            }
        }

        private static void IncreaseQualityByOne(Product product) => product.Quality += 1;

        private static void DecreaseQualityByOne(Product product) => product.Quality -= 1;

        private static bool SulfurasHandOfRagnaros(Product product) => product.Name == "Sulfuras, Hand of Ragnaros";

        private static bool BackstagePasses(Product product) => product.Name == "Backstage passes to a TAFKAL80ETC concert";

        private static bool AgedBrie(Product product) => product.Name == "Aged Brie";
        
        private static bool Conjured(Product product) => product.Name == "Conjured";
        
        private static bool Normal(Product product) => SulfurasHandOfRagnaros(product) || BackstagePasses(product) || AgedBrie(product) || Conjured(product);

        private static bool QualityLessThanFifty(Product product) => product.Quality < 50;

        private static bool QualityGreaterThanZero(Product product) => product.Quality > 0;

        private static bool SellInDateLessThanZero(Product product) => product.SellIn < 0;

        public void DisplayProducts()
        {
            _products.ForEach(product =>
            {
                Console.WriteLine($"Product: {product.Name}, Quality: {product.Quality}, Sell in {product.SellIn} days");
            });
        }
    }
}
