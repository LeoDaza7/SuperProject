using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    class ShippingAddressService : IService1<ShippingAddress>
    {
        public List<ShippingAddress> lista;
        public ShippingAddressService()
        {
            lista = new List<ShippingAddress>();
        }

        private int GetIndex(string key)
        {
            return lista.FindIndex((x => x.Identifier == key));
        }

        private bool Verification(ShippingAddress s)
        {
            return lista.Exists((x => x.Identifier == s.Identifier));
        }

        public bool Create(ShippingAddress newSA)
        {
            bool existe = !Verification(newSA);
            if (existe)
            {
                lista.Add(newSA);
            }
            return existe;
        }
        public List<ShippingAddress> Read()
        {
            ShippingAddress sa1 = new ShippingAddress() { Identifier = "casa", Line1 = "asd", Line2 = "123", Phone = 1, City = "cbba", Zone = "Temporal"};
            ShippingAddress sa2 = new ShippingAddress() { Identifier = "oficina", Line1 = "asd", Line2 = "123", Phone = 2, City = "cbba", Zone = "centro" };
            ShippingAddress sa3 = new ShippingAddress() { Identifier = "oficina2", Line1 = "asd", Line2 = "123", Phone = 3, City = "cbba", Zone = "America oeste" };
            ShippingAddress sa4 = new ShippingAddress() { Identifier = "casa2", Line1 = "asd", Line2 = "123", Phone = 4, City = "cbba", Zone = "parque Lincoln" };
            ShippingAddress sa5 = new ShippingAddress() { Identifier = "tienda", Line1 = "asd", Line2 = "123", Phone = 5, City = "cbba", Zone = "Muyurina" };
            lista.Add(sa1);
            lista.Add(sa2);
            lista.Add(sa3);
            lista.Add(sa4);
            lista.Add(sa5);
            return lista;
        }
        public bool Update(string key, ShippingAddress actualizado)
        {
            bool existe = true;
            if (!key.Equals(actualizado.Identifier))
                existe = false;
            if (existe)
            {
                int index = GetIndex(key);
                if (index != -1)
                    lista[index] = actualizado;
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
                lista.RemoveAt(index);
            else
                eliminado = false;
            return eliminado;
        }
    }
}
