using System;
using System.Collections.Generic;
using System.Threading;

namespace _2._2_Rallback
{
    class BalanceClosing : IAction
    {
        private BalancesDatabase _database;
        private BalancesUI _UI;

        private Stack<Balance> _closedCounts = new Stack<Balance>();

        public BalanceClosing(BalancesDatabase database)
        {
            _database = database;
            _UI = new BalancesUI(_database);
        }

        public void Execute()
        {
            Console.Clear();
            _UI.Display(60, 0);

            Console.Write("Введите номер счёта, который хотите закрыть: ");            
            long id = long.Parse(Console.ReadLine());

            Console.Clear();
            _UI.Display(80, 0);

            if (_database.IsBalanceExists(id))
            {
                Balance closedCount = _database.Get(id);
                _database.Remove(id);
                _closedCounts.Push(closedCount);
                Console.WriteLine("Счёт " + closedCount.Id + " c суммой " + closedCount.Value + " успешно закрыт");
            }
            else
                Console.WriteLine("Счёта номер " + id + " не существует в базе данных");            

            Thread.Sleep(1500);
        }

        public void Undo()
        {
            Balance lastClosedCount = _closedCounts.Pop();
            _database.Add(lastClosedCount);
        }
    }
}
