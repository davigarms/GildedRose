using System.Collections.Generic;

namespace GildedRose.Core
{
    public class Store
    {
        private readonly IList<Product> _products;

        public Store(IList<Product> products = null)
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
                UpdateAgedBrieQuality(item);
                UpdateBackStagePassesQuality(item);
            }
        }

        private void UpdateNormalProductsQuality(Product product)
        {
            if (SulfurasHandOfRagnaros(product) || BackstagePasses(product) || AgedBrie(product)) return;
            DecreaseQualityWhenGreaterThanZero(product);
            if (SellInDateLessThanZero(product))
                DecreaseQualityWhenGreaterThanZero(product);
        }

        private void UpdateAgedBrieQuality(Product product)
        {
            if (!AgedBrie(product)) return;
            IncreaseQualityWhenLessThanFifty(product);
            if (SellInDateLessThanZero(product))
                IncreaseQualityWhenLessThanFifty(product);
        }

        private void UpdateBackStagePassesQuality(Product product)
        {
            if (!BackstagePasses(product)) return;
            IncreaseQualityWhenLessThanFifty(product);
            IncreaseQualityWhenCloserToAConcertDate(product);
            if (SellInDateLessThanZero(product))
                DropQualityToZero(product);
        }

        private void IncreaseQualityWhenCloserToAConcertDate(Product product)
        {
            if (!BackstagePasses(product)) return;
            if (product.SellIn < 11)
                IncreaseQualityWhenLessThanFifty(product);

            if (product.SellIn < 6)
                IncreaseQualityWhenLessThanFifty(product);
        }

        private void DropQualityToZero(Product product)
        {
            product.Quality -= product.Quality;
        }

        private void DecreaseSellInDate(Product product)
        {
            if (!SulfurasHandOfRagnaros(product))
                product.SellIn -= 1;
        }

        private void IncreaseQualityWhenLessThanFifty(Product product)
        {
            if (QualityLessThanFifty(product))
                IncreaseQuality(product);
        }

        private void DecreaseQualityWhenGreaterThanZero(Product product)
        {
            if (QualityGreaterThanZero(product))
                DecreaseQuality(product);
        }

        private void IncreaseQuality(Product product) => product.Quality += 1;

        private void DecreaseQuality(Product product) => product.Quality -= 1;

        private bool SulfurasHandOfRagnaros(Product product) => product.Name == "Sulfuras, Hand of Ragnaros";

        private bool BackstagePasses(Product product) => product.Name == "Backstage passes to a TAFKAL80ETC concert";

        private bool AgedBrie(Product product) => product.Name == "Aged Brie";

        private bool QualityLessThanFifty(Product product) => product.Quality < 50;

        private bool QualityGreaterThanZero(Product product) => product.Quality > 0;

        private bool SellInDateLessThanZero(Product product) => product.SellIn < 0;
    }
}