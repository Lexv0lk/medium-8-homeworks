using System;

namespace _2._4_ProductWithDiscount
{
    class DiscountedProduct
    {
        public string Name { get; private set; }
        public float Price { get; private set; }

        public bool CanBeDelivered => false;

        public DiscountedProduct(Product product, int discountPercents)
        {
            Name = product.Name;
            Price = product.Price - product.Price * (discountPercents / 100f);
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public float Price { get; private set; }

        public bool CanBeDelivered => true;

        public Product(string name, float price)
        {
            Name = name;
            Price = price;
        }

        public DiscountedProduct AddDiscount(int percents)
        {
            if (percents < 0 || percents > 100)
                throw new ArgumentOutOfRangeException(nameof(percents));

            return new DiscountedProduct(this, percents);
        }
    }
}
