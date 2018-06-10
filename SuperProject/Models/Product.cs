using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject
{
    class Product
    { 

        private string code { get; set; }
        private string name { get; set; }
        private double price { get; set; }
        private string description { get; set; }
        private enum typeEnum : int { physical = 1, digital = 0, nulo = -1};
        private typeEnum type { get; set; }
        private enum shippingDeliveryTypeEnum : int { nulo = -1, express = 1, normal = 2, inStore = 3, free = 4, none = 0};
        private shippingDeliveryTypeEnum shippingDeliveryType { get; set; }
        private Category category { get; set; }

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

    }
}
