using System.Collections.Generic;

namespace DataModel
{
    public class Data
    {
        public List<Address> AddressList { get; set; }
        public int AI_Address;

        public List<Order> OrderList { get; set; }
        public int AI_Order;

        public List<User> UserList { get; set; }
        public int AI_User;

        public Data()
        {
            AddressList = new List<Address>();
            OrderList = new List<Order>();
            UserList = new List<User>();
        }

        public void AddUser(User usr)
        {
            UserList.Add(usr);
        }

        public void AddOrder(Order ord)
        {
            OrderList.Add(ord);
        }

        public void AddAddress(Address addr)
        {
            AddressList.Add(addr);
        }

        public void RemoveUser(User usr)
        {
            UserList.Remove(usr);
        }

        public void RemoveOrder(Order ord)
        {
            OrderList.Remove(ord);
        }

        public void RemoveAddress(Address addr)
        {
            AddressList.Remove(addr);
        }
    }
}
