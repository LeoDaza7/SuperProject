using SuperProject.Services;
using System;

namespace SuperProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService ps = new ProductService();
            ps.ejemploLista();

            Console.WriteLine("Lista de ejemplo para trabajar\n");
            foreach(Product p in ps.read())
            {
                Console.WriteLine(p.toString());
            }

            Console.WriteLine("Introduciendo un codigo existente\n");
            Product ej1 = new Product();
            ej1.code = "1";
            ej1.name = "Huawei Mate 10 Lite";
            ej1.price = 270.75;
            ej1.description = "RNE-L23";
            ej1.type = Product.typeEnum.physical;
            ej1.shippingDeliveryType = Product.shippingDeliveryTypeEnum.express;
            ej1.category = null;
            ps.create((Object) ej1);

            Console.WriteLine("Introduciendo un codigo nuevo\n");
            ej1.code = "31";
            ps.create((Object) ej1);

            Console.WriteLine("Revisando los cambios realizados\n");
            foreach (Product p in ps.read())
            {
                Console.WriteLine(p.toString());
            }

            Console.WriteLine("Actualizando un producto inexistente\n");
            Product ej2 = new Product();
            ej2.code = "15";
            ej2.name = "Huawei Mate 10 pro";
            ej2.price = 270.75;
            ej2.description = "...";
            ej2.type = Product.typeEnum.physical;
            ej2.shippingDeliveryType = Product.shippingDeliveryTypeEnum.express;
            ej2.category = null;
            ps.Update(ej2.code, (Object) ej2);

            Console.WriteLine("Actualizando un producto existente\n");
            ej2.code = "0";
            ps.Update(ej2.code, (Object) ej2);

            Console.WriteLine("Revisando los cambios realizados\n");
            foreach (Product p in ps.read())
            {
                Console.WriteLine(p.toString());
            }

            Console.WriteLine("Borrando un producto que no existe en la lista la lista\n");
            ps.Delete("5");

            Console.WriteLine("Borrando un producto de la lista");
            ps.Delete("1");

            Console.WriteLine("Revisando los cambios realizados\n");
            foreach (Product p in ps.read())
            {
                Console.WriteLine(p.toString());
            }


            Console.ReadKey();
        }
    }
}
