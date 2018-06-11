using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    class ShippingAddressService
    {
        public List<ShippingAddress> lista;
        public ShippingAddressService()
        {
            lista = new List<ShippingAddress>();
        }
        public bool create(string identifier, string line1, string line2, int phone, string city, string zone)
        {
            ShippingAddress newSA = new ShippingAddress();
            newSA.Identifier = identifier;
            bool estado = true;
            foreach (ShippingAddress sa in lista)
            {
                if (sa.Identifier.Equals(identifier))
                {
                    estado = false;
                }
            }
            if (estado)
            {
                newSA.Identifier = identifier;
                newSA.Line1 = line1;
                newSA.Line2 = line2;
                newSA.Phone = phone;
                newSA.City = city;
                newSA.Zone = zone;
                lista.Add(newSA);
            }
            return estado;
        }
        public List<ShippingAddress> read()
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
            bool actualizable = false;
            foreach(ShippingAddress sa in lista)
            {
                if (sa.Identifier.Equals(key))
                {
                    sa.City = actualizado.City;
                    sa.Line1 = actualizado.Line1;
                    sa.Line2 = actualizado.Line2;
                    sa.Zone = actualizado.Zone;
                    sa.Phone = actualizado.Phone;
                    actualizable = true;
                    break;
                }
            }
            return actualizable;
        }
        public bool Delete(string key)
        {
            bool eliminado = false;
            ShippingAddress auxiliar = null;
            foreach(ShippingAddress sa in lista)
            {
                if (sa.Identifier.Equals(key))
                {
                    lista.Remove(sa);
                    eliminado = true;
                    break;
                }
            }
            return eliminado;
        }
    }
}
