using System;
using System.Linq;

namespace _2._2_Rallback
{
    class BalancesUI
    {
        private BalancesDatabase _database;

        public BalancesUI(BalancesDatabase database)
        {
            _database = database;
        }

        public void Display(int x, int y)
        {
            Balance[] counts = _database.GetAll().ToArray();
            for (int i = 0; i < counts.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write($"Счёт {counts[i].Id} - {counts[i].Value} рублей");
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
