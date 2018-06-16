using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    public class ProductService : IService1<Product>
    {
        public SuperDB instance;
        public ProductService()
        {
            instance = SuperDB.Instance;
        }
        public int GetIndex(string key)
        {
            return instance.ProductsList.FindIndex((x => x.Code == key));
        }

        public bool Verification(Product p)
        {
            return instance.ProductsList.Exists((x => x.Code == p.Code));
        }
        
        public bool Create(Product producto)
        {
            bool estado = !Verification(producto);
            if (estado)
            {
                instance.ProductsList.Add(producto);
            }
            return estado;
        }

        public List<Product> Read()
        {
            return instance.ProductsList;
        }

        public bool Update(string codigo, Product producto)
        {
            bool estado = true;
            if (!codigo.Equals(producto.Code))
                estado = false;
            if (estado)
            {
                int index = GetIndex(codigo);
                if (index != -1)
                    instance.ProductsList[index] = producto;
                else
                    estado = false;
            }
            return estado;
        }

        public bool Delete(String codigo)
        {
            bool estado = true;
            int index = GetIndex(codigo);
            if (index != -1)
                instance.ProductsList.RemoveAt(index);
            else
                estado = false;
            return estado;
        }
    }
}
