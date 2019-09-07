using System;
using System.Collections.Generic;
using System.Threading;

namespace _2._2_Rallback
{
    class CountOpening : IAction
    {
        private CountsDatabase _database;
        private Stack<Count> _createdCounts = new Stack<Count>();

        public CountOpening(CountsDatabase database)
        {
            _database = database;
        }

        public void Execute()
        {
            Console.Clear();
            Console.Write("Введите начальную сумму счета: ");

            int value = int.Parse(Console.ReadLine());
            Count newCount = new Count(value);
            _database.Add(newCount);
            _createdCounts.Push(newCount);

            Console.Clear();
            Console.WriteLine("Счёт " + newCount.Id + " c суммой " + newCount.Value + " успешно открыт");
            Thread.Sleep(1500);
        }

        public void Undo()
        {
            if (_createdCounts.Count == 0)
                return;

            long lastCountId = _createdCounts.Pop().Id;
            _database.Remove(lastCountId);
        }
    }
}
