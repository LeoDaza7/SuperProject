using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    public class StoreService : IService1<Store>
    {
        List<Store> dBstore;
        
        public StoreService()
        {
            dBstore = new List<Store>();
        }
        private int GetIndex(string key)
        {
            return dBstore.FindIndex((x => x.Name == key));
        }

        private bool Verification(Store store)
        {
            return dBstore.Exists((x => x.Name == store.Name));
        }

        public bool Create(Store store)
        {
            bool existe = !Verification(store);
            if (existe)
            {
                dBstore.Add(store);
            }
            return existe;
        }
        public List<Store> Read()
        {
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
            bool existe = true;
            if (!name.Equals(store.Name))
                existe = false;
            if (existe)
            {
                int index = GetIndex(name);
                if (index != -1)
                    dBstore[index] = store;
                else
                    existe = false;
            }
            return existe;
        }
        public bool Delete(string name)
        {
            bool eliminado = true;
            int index = GetIndex(name);
            if (index != -1)
                dBstore.RemoveAt(index);
            else
                eliminado = false;
            return eliminado;
        }
    }
}