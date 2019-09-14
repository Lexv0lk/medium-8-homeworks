using System.Collections.Generic;

namespace _3._2_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>() { new Product("Пирожок", 35, 4), new Product("Булочка", 20, 1), new Product("Пицца", 500, 8), new Product("Бублик", 50, 7) };
            Product targetProduct = products.Find(product => product.Price < 100 && product.Count > 6);
        }
    }

    class Product
    {
        public int Id { get; }
        public string Name { get; private set; }

        public int Price { get; private set; }        
        public int Count { get; private set; }

        private static int _currentId = 0;

        public Product(string name, int price, int count)
        {
            Id = _currentId++;
            Name = name;
            Price = price;
            Count = count;
        }
    }
}
