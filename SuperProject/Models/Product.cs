using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject
{
    public class Product
    { 

        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public enum typeEnum : int { physical = 1, digital = 0, nulo = -1};
        public typeEnum Type { get; set; }
        public enum shippingDeliveryTypeEnum : int { nulo = -1, express = 1, normal = 2, inStore = 3, free = 4, none = 0};
        public shippingDeliveryTypeEnum ShippingDeliveryType { get; set; }
        public Category Category { get; set; }

        public Product()
        {
            Code = "";
            Name = "";
            Price = 0.0;
            Description = "";
            Type = typeEnum.nulo;
            ShippingDeliveryType = shippingDeliveryTypeEnum.nulo;
            Category = null;
        }

        public string toString()
        {
            return "Codigo = " + Code + "\nNombre = " + Name + "\nPrecio = " + Price + "\nTipo = " + Type + "\nTipo de entrega = " + ShippingDeliveryType + "\nCategoria = " + Category;
        }
            
    }
}
