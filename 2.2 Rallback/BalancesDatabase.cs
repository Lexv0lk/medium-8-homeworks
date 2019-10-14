using System.Collections.Generic;
using System.Linq;

namespace _2._2_Rallback
{
    class BalancesDatabase
    {
        private List<Balance> _balances = new List<Balance>();

        public void Add(Balance count) => _balances.Add(count);

        public void Remove(long id) => _balances.RemoveAll(count => count.Id == id);

        public IReadOnlyCollection<Balance> GetAll() => _balances;

        public Balance Get(long id) => _balances.FirstOrDefault(count => count.Id == id);

        public bool IsBalanceExists(long id) => _balances.FirstOrDefault(count => count.Id == id) != null;
    }
}
