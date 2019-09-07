using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._2_Rallback
{
    class CountClosing : IAction
    {
        private CountsDatabase _database;
        private CountsUI _UI;

        private Stack<Count> _closedCounts = new Stack<Count>();

        public CountClosing(CountsDatabase database)
        {
            _database = database;
            _UI = new CountsUI(_database);
        }

        public void Execute()
        {
            Console.Clear();
            _UI.Display(60, 0);

            Console.Write("Введите номер счёта, который хотите закрыть: ");            
            long id = long.Parse(Console.ReadLine());

            Console.Clear();
            _UI.Display(80, 0);

            if (_database.IsCountExists(id))
            {
                Count closedCount = _database.Get(id);
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
            Count lastClosedCount = _closedCounts.Pop();
            _database.Add(lastClosedCount);
        }
    }
}
