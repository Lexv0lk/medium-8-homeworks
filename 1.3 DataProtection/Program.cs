using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._3_DataProtection
{
    class Bag
    {
        private List<Item> _items;
        private int _maxWidth;

        public Bag(uint maxWidth)
        {
            _maxWidth = (int)maxWidth;
        }

        public void AddItem(string name, int count)
        {
            int currentWidth = _items.Sum(item => item.Count);
            Item targetItem = _items.FirstOrDefault(item => item.Name == name);

            if (targetItem == null)
                throw new InvalidOperationException();

            if (currentWidth + count > _maxWidth)
                throw new InvalidOperationException();

            targetItem.AddCount(count);
        }

        public IReadOnlyCollection<Item> GetAllItems() => _items;
    }

    class Item
    {
        public int Count { get; private set; }
        public string Name { get; }

        public Item(string name)
        {
            Name = name;
        }

        public void AddCount(int count) => Count += count;
    }
}
