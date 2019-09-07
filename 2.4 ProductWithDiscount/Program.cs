using System;

namespace _2._4_ProductWithDiscount
{
    class Product
    {
        public string Name { get; private set; }
        public bool HasDiscount { get; private set; }

        public bool CanBeDelivered => !HasDiscount;

        private float _price;
        private int _discountPercents;

        public float GetPrice() => _price;
        public float GetPriceWithDiscount() => _price - _discountPercents / 100f * _price;

        public void SetDiscount(int percents)
        {
            if (percents < 0 || percents > 100)
                throw new ArgumentOutOfRangeException();

            HasDiscount = true;
            _discountPercents = percents;
        }

        public void RemoveDiscount()
        {
            HasDiscount = false;
            _discountPercents = 0;
        }
    }
}
