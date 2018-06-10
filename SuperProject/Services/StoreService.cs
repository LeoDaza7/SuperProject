using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    class StoreService
    {
        List<Store> dbStore = new List<Store>();
        public bool create(string name, string line1, string line2, int phone)
        {
            Store auxStore = new Store();
            auxStore.Name = name;
            foreach (Store element in dbStore)
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
            dbStore.Add(auxStore);
            return true;
        }
        public List<Store> read()
        {
            List<Store> dBstore = new List<Store>();
            Store store1 = new Store() {Name="New York", Line1= "a", Line2="b",Phone= 1};
            Store store2 = new Store() { Name = "Chicago", Line1 = "c", Line2 = "d", Phone = 2 };
            Store store3 = new Store() { Name = "La Paz", Line1 = "e", Line2 = "f", Phone = 3 };
            Store store4 = new Store() { Name = "Cochabamba", Line1 = "g", Line2 = "h", Phone = 4 };
            Store store5 = new Store() { Name = "Moscu", Line1 = "i", Line2 = "j", Phone = 5 };
            dBstore.Add(store1);
            dBstore.Add(store2);
            dBstore.Add(store3);
            dBstore.Add(store4);
            dBstore.Add(store5);
            return dBstore;
        }
        public bool Update(string name, Store store)
        {
            foreach (Store element in dbStore)
            {
                if (element.Name.Equals(name))
                {
                    element.Name = store.Name;
                    element.Line1 = store.Line1;
                    element.Line2 = store.Line2;
                    element.Phone = store.Phone;
                    return true;
                }
            }
            return false;
        }
        public bool Delete(string name)
        {
            foreach (Store element in dbStore)
            {
                if (element.Name.Equals(name))
                {
                    dbStore.Remove(element);
                    return true;
                }
            }
            return false;
        }
    }
}