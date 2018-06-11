using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    class ProductService
    {
        private List<Product> productos = new List<Product>();
        public void ejemploLista()
        {
            Product p1 = new Product();
            p1.code = "0";
            p1.name = "Head Phones";
            p1.price = 20.75;
            p1.description = "Audifonos huawei";
            p1.type = Product.typeEnum.physical;
            p1.shippingDeliveryType = Product.shippingDeliveryTypeEnum.inStore;
            p1.category = null;
            productos.Add(p1);

            Product p2 = new Product();
            p2.code = "1";
            p2.name = "Mouse";
            p2.price = 17.5;
            p2.description = "Mouse inalambrico para portatil";
            p2.type = Product.typeEnum.physical;
            p2.shippingDeliveryType = Product.shippingDeliveryTypeEnum.express;
            p2.category = null;
            productos.Add(p2);

            Product p3 = new Product();
            p3.code = "2";
            p3.name = "Windows Pro";
            p3.price = 120.75;
            p3.description = "Licencia digital para activacion de Windows Pro";
            p3.type = Product.typeEnum.digital;
            p3.shippingDeliveryType = Product.shippingDeliveryTypeEnum.none;
            p3.category = null;
            productos.Add(p3);
        }

        public bool create(Object producto)
        {
            bool estado = true;
            Product aux = (Product) producto;
            foreach(Product p in productos)
            {
                if (p.code.Equals(aux.code))
                {
                    Console.WriteLine("Intente con un nuevo codigo");
                    estado = false;
                }
            }
            if (estado)
            {
                productos.Add(aux);
            }
            return estado;
        }

        public List<Product> read()
        {
            return productos;
        }
        public bool Update(string codigo, Object producto)
        {
            bool estado = false;
            Product aux = (Product) producto;
            foreach(Product p in productos)
            {
                if(p.code.Equals(codigo))
                {
                    p.name = aux.name;
                    p.price = aux.price;
                    p.description = aux.description;
                    p.type = aux.type;
                    p.shippingDeliveryType = aux.shippingDeliveryType;
                    estado = true;
                    Console.WriteLine("Producto actualizado");
                }
            }
            if(!estado)
            {
                Console.WriteLine("Producto inexistente");
            }
            return estado;
        }
        public bool Delete(String codigo)
        {
            bool estado = false;
            Product aux = new Product();
            foreach(Product p in productos)
            {
                if (p.code.Equals(codigo))
                {
                    aux = p;
                    estado = true;
                }
            }
            if (!estado)
            {
                Console.WriteLine("Producto inexistente");
            }
            else
            {
                productos.Remove(aux);
                Console.WriteLine("Producto eliminado");
            }
            return estado;
        }
    }
}
