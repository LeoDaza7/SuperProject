using Models;
using SuperProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class OrderHistoryService:IService1<OrderHistory>
    {
        public SuperDB instance;
        public OrderHistoryService()
        {
            instance = SuperDB.Instance;
        }
        public int GetIndex(string Username)
        {
            return instance.OrderHistoryList.FindIndex((x => x.UserName == Username));
        }

        public bool Verification(OrderHistory c)
        {
            return instance.OrderHistoryList.Exists((x => x.UserName == c.UserName));
        }

        public bool Create(OrderHistory oh)
        {
            bool existe = !Verification(oh);
            if (existe)
            {
                instance.OrderHistoryList.Add(oh);
            }
            return existe;
        }

        public List<OrderHistory> Read()
        {
            return instance.OrderHistoryList;
        }

        public bool Update(string key, OrderHistory oh)
        {
            int index = GetIndex(key);
            bool existe = true;
            if (!key.Equals(oh.UserName))
            {
                if (GetIndex(oh.UserName) != -1)
                    existe = false;
                else
                    existe = true;
            }
            if (existe)
            {
                if (index != -1)
                    instance.OrderHistoryList[index] = oh;
                else
                    existe = false;
            }
            return existe;
        }

        public bool Delete(string key)
        {
            bool eliminado = true;
            int index = GetIndex(key);
            if (index != -1)
                instance.OrderHistoryList.RemoveAt(index);
            else
                eliminado = false;
            return eliminado;
        }
    }
}
