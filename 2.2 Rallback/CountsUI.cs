using System;
using System.Linq;

namespace _2._2_Rallback
{
    class CountsUI
    {
        private CountsDatabase _database;

        public CountsUI(CountsDatabase database)
        {
            _database = database;
        }

        public void Display(int x, int y)
        {
            Count[] counts = _database.GetAll().ToArray();
            for (int i = 0; i < counts.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write($"Счёт {counts[i].Id} - {counts[i].Value} рублей");
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
