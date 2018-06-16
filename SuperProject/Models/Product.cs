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
        public string ImageURL { get; set; }
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
            ImageURL = "";
            Type = typeEnum.nulo;
            ShippingDeliveryType = shippingDeliveryTypeEnum.nulo;
            Category = null;
        }

        public string toString()
        {
            return "Codigo = " + Code + "\nNombre = " + Name + "\nPrecio = " + Price + "\nTipo = " + Type + "\nTipo de entrega = " + ShippingDeliveryType + "\nCategoria = " + Category;
        }

        public void setType(string tipo)
        {
            switch (tipo)
            {
                case "physical":
                    this.Type = typeEnum.physical;
                    break;
                case "digital":
                    this.Type = typeEnum.digital;
                    this.ShippingDeliveryType = shippingDeliveryTypeEnum.none;
                    break;
                default:
                    this.Type = typeEnum.nulo;
                    break;
            }
        }

        public typeEnum getType()
        {
            return this.Type;
        }

        public void setShippingDT(string ship)
        {
            if (!Type.ToString().Equals("digital"))
            {
                switch (ship)
                {
                    case "express":
                        this.ShippingDeliveryType = shippingDeliveryTypeEnum.express;
                        break;
                    case "normal":
                        this.ShippingDeliveryType = shippingDeliveryTypeEnum.normal;
                        break;
                    case "inStore":
                        this.ShippingDeliveryType = shippingDeliveryTypeEnum.inStore;
                        break;
                    case "free":
                        this.ShippingDeliveryType = shippingDeliveryTypeEnum.free;
                        break;
                    default:
                        this.ShippingDeliveryType = shippingDeliveryTypeEnum.nulo;
                        break;
                }
            }
        }

        public shippingDeliveryTypeEnum getShippingDT()
        {
            return this.ShippingDeliveryType;
        }
            
    }
}
