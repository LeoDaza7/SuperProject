using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    class StoreService
    {
        List<Store> list = new List<Store>();

        public bool create(string name, string line1, string line2, int phone)
        {
            Store auxStore = new Store();
            auxStore.Name = name;
            foreach (Store element in list)
            {
                if (element.Name.Equals(name))
                {
                    Console.WriteLine("Name already exists\ntry to create again");
                    return false;
                }
            }
            auxStore.Line1 = line1;
            auxStore.Line2 = line2;
            auxStore.Phone = phone;
            list.Add(auxStore);
            return true;
        }
        public List<Store> read()
        {
            return list;
        }
        public bool Update(string name, Store store)
        {
            foreach (Store element in list)
            {
                if (element.Name.Equals(name))
                {
                    element.Name = store.Name;
                    element.Line1 = store.Line1;
                    element.Line2 = store.Line2;
                    element.Phone = store.Phone;
                }
            }
            return false;
        }
        public bool Delete(string name)
        {
            foreach (Store element in list)
            {
                if (element.Name.Equals(name))
                {
                    list.Remove(element);
                    return true;
                }
            }
            return false;
        }
    }
}