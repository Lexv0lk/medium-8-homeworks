using System;
using System.Collections.Generic;

namespace _3._1_Sorting
{
    class Goods
    {
        private List<Good> _goods = new List<Good>();

        public Goods(List<Good> goods)
        {
            _goods = goods;
        }

        public Good At(int index)
        {
            if (index < 0 || index >= _goods.Count)
                throw new IndexOutOfRangeException();

            return _goods[index];
        }

        public void Sort(Comparison<Good> comparison) => _goods.Sort(comparison);
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
