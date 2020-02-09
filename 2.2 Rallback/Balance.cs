using System;

namespace _2._2_Rallback
{
    class Balance
    {
        public readonly long Id;
        public int Value { get; private set; }

        private static long _currentId = 1;

        public Balance(int value)
        {
            Value = value;
            Id = _currentId++;
        }

        public void Distruct(int value)
        {
            if (value > Value || value < 0)
                throw new ArgumentOutOfRangeException();

            Value -= value;
        }

        public void Add(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException();

            Value += value;
        }
    }
}
