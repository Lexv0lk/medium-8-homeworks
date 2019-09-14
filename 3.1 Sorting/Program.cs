using System;
using System.Collections.Generic;
using System.Linq;
namespace _3._1_Sorting
{
    class GoodsList
    {
        private List<Good> _goods = new List<Good>();

        public GoodsList(List<Good> goods)
        {
            _goods = goods;
        }

        public Good At(int index)
        {
            if (index < 0 || index >= _goods.Count)
                throw new IndexOutOfRangeException();

            return _goods[index];
        }

        public void SortByNames(Comparison<string> comparison) => _goods.Sort((x, y) => comparison(x.Name, y.Name));
        public void SortByPrice(Comparison<int> comparison) => _goods.Sort((x, y) => comparison(x.Price, y.Price));
        public void SortByLevel(Comparison<int> comparison) => _goods.Sort((x, y) => comparison(x.Level, y.Level));
    }

    class Good
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int Level { get; private set; }

        public Good(string name, int price, int level)
        {
            Name = name;
            Price = price;
            Level = level;
        }
    }
}
