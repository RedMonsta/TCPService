using System.Collections.Generic;

namespace DataModel
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> OrderList { get; set; }
        public List<int> AddressList { get; set; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
            OrderList = new List<int>();
            AddressList = new List<int>();
        }
    }
}
