using System;
using System.Collections.Generic;
using System.Threading;

namespace _2._2_Rallback
{
    class BalanceOpening : IAction
    {
        private BalancesDatabase _database;
        private Stack<Balance> _createdBalances = new Stack<Balance>();

        public BalanceOpening(BalancesDatabase database)
        {
            _database = database;
        }

        public void Execute()
        {
            Console.Clear();
            Console.Write("Введите начальную сумму счета: ");

            int value = int.Parse(Console.ReadLine());
            Balance newCount = new Balance(value);
            _database.Add(newCount);
            _createdBalances.Push(newCount);

            Console.Clear();
            Console.WriteLine("Счёт " + newCount.Id + " c суммой " + newCount.Value + " успешно открыт");
            Thread.Sleep(1500);
        }

        public void Undo()
        {
            if (_createdBalances.Count == 0)
                return;

            long lastCountId = _createdBalances.Pop().Id;
            _database.Remove(lastCountId);
        }
    }
}
