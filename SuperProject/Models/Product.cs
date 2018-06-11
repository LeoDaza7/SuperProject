using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject
{
    class Product
    { 

        public string code { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public enum typeEnum : int { physical = 1, digital = 0, nulo = -1};
        public typeEnum type { get; set; }
        public enum shippingDeliveryTypeEnum : int { nulo = -1, express = 1, normal = 2, inStore = 3, free = 4, none = 0};
        public shippingDeliveryTypeEnum shippingDeliveryType { get; set; }
        public Category category { get; set; }

        public Product()
        {
            code = "";
            name = "";
            price = 0.0;
            description = "";
            type = typeEnum.nulo;
            shippingDeliveryType = shippingDeliveryTypeEnum.nulo;
            category = null;
        }

        public string toString()
        {
            return "Codigo = " + code + "\nNombre = " + name + "\nPrecio = " + price + "\nTipo = " + type + "\nTipo de entrega = " + shippingDeliveryType + "\nCategoria = " + category;
        }
            
    }
}
