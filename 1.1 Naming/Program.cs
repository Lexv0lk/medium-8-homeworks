using System.Collections.Generic;
using System.Linq;

namespace _1._1_Naming
{
    class UserStorage
    {
        private List<User> _users = new List<User>();

        public void AddUser(User user) => _users.Add(user);
        public void RemoveUser(User user) => _users.Remove(user);

        public User GetUser(string name) => _users.Where(x => x.Name == name).FirstOrDefault();
        public User GetUser(int id) => _users.Where(x => x.Id == id).FirstOrDefault();

        public IReadOnlyCollection<User> GetAllUsers() => _users;

        public IEnumerable<User> GetUsersWithHigherSalary(int salary) => _users.Where(x => x.Salary > salary);
        public IEnumerable<User> GetUsersWithLowerSalary(int salary) => _users.Where(x => x.Salary < salary);
        public IEnumerable<User> GetUsersInSalaryRange(int lowerSalary, int highestSalary) => _users.Where(x => x.Salary > lowerSalary && x.Salary < highestSalary);
    }

    class User
    {
        static private int _currentId = 0;

        public int Id { get; }
        public string Name { get; private set; }
        public int Salary { get; private set; }

        public User(string name, int salary)
        {
            Id = ++_currentId;
            Name = name;
            Salary = salary;
        }
    }
}
