using System.Collections.Generic;
using System.Linq;

namespace _2._2_Rallback
{
    class CountsDatabase
    {
        private List<Count> _countsList = new List<Count>();

        public void Add(Count count) => _countsList.Add(count);
        public void Remove(long id) => _countsList.RemoveAll(count => count.Id == id);

        public IReadOnlyCollection<Count> GetAll() => _countsList;
        public Count Get(long id) => _countsList.FirstOrDefault(count => count.Id == id);

        public bool IsCountExists(long id) => _countsList.FirstOrDefault(count => count.Id == id) != null;
    }
}
