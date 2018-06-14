using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject
{
    class ProductCart
    {
        public string ProductCode {get; set;}
        public enum shippingDeliveryTypeEnum : int { nulo = -1, express = 1, normal = 2, inStore = 3, free = 4, none = 0 };
        public shippingDeliveryTypeEnum ShippingDeliveryType { get; set; }
        public Store Store { get; set;}
        public int Quantity { get; set;}

    }
}
