using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    class ProductService : IService1<Product>
    {
        public List<Product> productos = new List<Product>();

        private int GetIndex(string key)
        {
            return productos.FindIndex((x => x.Code == key));
        }

        private bool Verification(Product p)
        {
            return productos.Exists((x => x.Code == p.Code));
        }
        public void ejemploLista()
        {
            Product p1 = new Product();
            p1.Code = "0";
            p1.Name = "Head Phones";
            p1.Price = 20.75;
            p1.Description = "Audifonos huawei";
            p1.Type = Product.typeEnum.physical;
            p1.ShippingDeliveryType = Product.shippingDeliveryTypeEnum.inStore;
            p1.Category = null;
            productos.Add(p1);

            Product p2 = new Product();
            p2.Code = "1";
            p2.Name = "Mouse";
            p2.Price = 17.5;
            p2.Description = "Mouse inalambrico para portatil";
            p2.Type = Product.typeEnum.physical;
            p2.ShippingDeliveryType = Product.shippingDeliveryTypeEnum.express;
            p2.Category = null;
            productos.Add(p2);

            Product p3 = new Product();
            p3.Code = "2";
            p3.Name = "Windows Pro";
            p3.Price = 120.75;
            p3.Description = "Licencia digital para activacion de Windows Pro";
            p3.Type = Product.typeEnum.digital;
            p3.ShippingDeliveryType = Product.shippingDeliveryTypeEnum.none;
            p3.Category = null;
            productos.Add(p3);
        }

        public bool Create(Product producto)
        {
            bool estado = !Verification(producto);
            if (estado)
            {
                productos.Add(producto);
            }
            return estado;
        }

        public List<Product> Read()
        {
            ejemploLista();
            return productos;
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
                    productos[index] = producto;
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
                productos.RemoveAt(index);
            else
                estado = false;
            return estado;
        }
    }
}
