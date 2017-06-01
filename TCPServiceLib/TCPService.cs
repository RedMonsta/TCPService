using System.IO;
using DataModel;
using System;
using System.Text;

namespace TCPServiceLib
{
    public class TCPService
    {
        private DataModel.Data data;
        private string path;

        public TCPService()
        {
            data = new Data();
            path = @"C:\Users\vambr\Desktop\TCPdata.txt";
            Load();
        }

        public int AddUser(string name)
        {
            var user = new User(data.AI_User++, name);
            data.AddUser(user);
            Save();
            return user.Id;
        }

        public int AddAddress(string city, string street, int build, int flat)
        {
            var addr = new Address(data.AI_Address++, city, street, build, flat);
            data.AddAddress(addr);
            Save();
            return addr.Id;
        }

        public int AddOrder(string goodname)
        {
            var ord = new Order(data.AI_Order++, goodname);
            data.AddOrder(ord);
            Save();
            return ord.Id;
        }


        public bool RemoveUser(int UserId)
        {
            if (data.UserList.Exists(x => x.Id == UserId))
            {
                data.RemoveUser(data.UserList.Find(x => x.Id == UserId));
                foreach (var addr in data.AddressList)
                {
                    if (addr.UserList.Exists(x => x == UserId))
                        addr.UserList.Remove(UserId);
                }
                foreach (var ord in data.OrderList)
                {
                    if (ord.UserID == UserId)
                        ord.UserID = -1;
                }
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveOrder(int OrdId)
        {
            if (data.OrderList.Exists(x => x.Id == OrdId))
            {
                data.RemoveOrder(data.OrderList.Find(x => x.Id == OrdId));
                foreach (var addr in data.AddressList)
                {
                    if (addr.OrderList.Exists(x => x == OrdId))
                        addr.OrderList.Remove(OrdId);
                }
                foreach (var user in data.UserList)
                {
                    if (user.OrderList.Exists(x => x == OrdId))
                        user.OrderList.Remove(OrdId);
                }
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveAddress(int AddrId)
        {
            if (data.AddressList.Exists(x => x.Id == AddrId))
            {
                data.RemoveAddress(data.AddressList.Find(x => x.Id == AddrId));
                foreach (var user in data.UserList)
                {
                    if (user.AddressList.Exists(x => x == AddrId))
                        user.AddressList.Remove(AddrId);
                }
                foreach (var ord in data.OrderList)
                {
                    if (ord.AddressID == AddrId)
                        ord.AddressID = -1;
                }
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool AddOrderToUser(int OrdId, int UserId)
        {
            if (data.UserList.Exists(x => x.Id == UserId) && data.OrderList.Exists(x => x.Id == OrdId))
            {
                if (data.OrderList.Find(x => x.Id == OrdId).UserID == -1)
                {
                    data.UserList.Find(x => x.Id == UserId).OrderList.Add(OrdId);
                    data.OrderList.Find(x => x.Id == OrdId).UserID = UserId;
                    Save();
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public bool AddAddressToUser(int AddrId, int UserId)
        {
            if (data.AddressList.Exists(x => x.Id == AddrId) && data.OrderList.Exists(x => x.Id == UserId))
            {
                if (data.UserList.Find(x => x.Id == UserId).AddressList.Exists(x => x == AddrId) == false)
                {
                    data.UserList.Find(x => x.Id == UserId).AddressList.Add(AddrId);
                    data.AddressList.Find(x => x.Id == AddrId).UserList.Add(UserId);
                    Save();
                    return true;
                }
                else return false;
            }
            else
            {
                return false;
            }
        }

        public bool AddUserToAddress(int UserId, int AddrId)
        {
            if (data.AddressList.Exists(x => x.Id == AddrId) && data.UserList.Exists(x => x.Id == UserId))
            {
                if (data.AddressList.Find(x => x.Id == AddrId).UserList.Exists(x => x == UserId) == false)
                {
                    data.AddressList.Find(x => x.Id == AddrId).UserList.Add(UserId);
                    data.UserList.Find(x => x.Id == UserId).AddressList.Add(AddrId);
                    Save();
                    return true;
                }
                else return false;
            }
            else
            {
                return false;
            }
        }

        public bool AddOrderToAddress(int OrdId, int AddrId)
        {
            if (data.AddressList.Exists(x => x.Id == AddrId) && data.OrderList.Exists(x => x.Id == OrdId))
            {
                if (data.OrderList.Find(x => x.Id == OrdId).AddressID == -1)
                {
                    data.AddressList.Find(x => x.Id == AddrId).OrderList.Add(OrdId);
                    data.OrderList.Find(x => x.Id == OrdId).AddressID = AddrId;
                    Save();
                    return true;
                }
                else return false;
            }
            else return false;
        }


        public bool RemoveOrderFromUser(int OrdId, int UserId)
        {
            try
            {
                if (data.UserList.Exists(x => x.Id == UserId))
                {
                    if (data.UserList.Find(x => x.Id == UserId).OrderList.Exists(x => x == OrdId))
                    {
                        data.UserList.Find(x => x.Id == UserId).OrderList.Remove(OrdId);
                        data.OrderList.Find(x => x.Id == OrdId).UserID = -1;
                        Save();
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveAddressFromUser(int AddrId, int UserId)
        {
            try
            {
                if (data.UserList.Exists(x => x.Id == UserId))
                {
                    if (data.UserList.Find(x => x.Id == UserId).AddressList.Exists(x => x == AddrId))
                    {
                        data.UserList.Find(x => x.Id == UserId).AddressList.Remove(AddrId);
                        data.AddressList.Find(x => x.Id == AddrId).UserList.Remove(UserId);
                        Save();
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveUserFromAddress(int UserId, int AddrId)
        {
            try
            {
                if (data.AddressList.Exists(x => x.Id == AddrId))
                {
                    if (data.AddressList.Find(x => x.Id == AddrId).UserList.Exists(x => x == UserId))
                    {
                        data.AddressList.Find(x => x.Id == AddrId).UserList.Remove(UserId);
                        data.UserList.Find(x => x.Id == UserId).AddressList.Remove(AddrId);
                        Save();
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveOrderFromAddress(int OrdId, int AddrId)
        {
            try
            {
                if (data.AddressList.Exists(x => x.Id == AddrId))
                {
                    if (data.AddressList.Find(x => x.Id == AddrId).OrderList.Exists(x => x == OrdId))
                    {
                        data.AddressList.Find(x => x.Id == AddrId).OrderList.Remove(OrdId);
                        data.OrderList.Find(x => x.Id == OrdId).AddressID = -1;
                        Save();
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public string GetData()
        {
            return DataSerializer.Serialize(data);
        }

        private void Load()
        {
            string jsondata = File.ReadAllText(path, Encoding.UTF8);
            data = DataSerializer.Deserialize(jsondata);
        }

        private void Save()
        {
            string jsondata = DataSerializer.Serialize(data);
            File.WriteAllText(path, jsondata, Encoding.UTF8);
        }
    }
}
