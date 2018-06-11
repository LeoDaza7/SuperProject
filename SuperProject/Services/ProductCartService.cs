using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperProject.Services
{
   class ProductCartService
    {
        public List<ProductCart> listPC;
        public ProductCartService() { 
        }
        private int getProductCartIndex(string productCode)
        {
            return listPC.FindIndex((x => x.ProductCode == productCode));
        }

        public bool productCartVerification(ProductCart pc)
        {
            return listPC.Exists((x => x.ProductCode == pc.ProductCode));
        }


        public bool create(ProductCart pc)
        {
            if (productCartVerification(pc))
            {
                return false;
            }else if (pc.shippingDeliveryType != ProductCart.shippingDeliveryTypeEnum.inStore)
            {
                pc.Store = null;
            }

            listPC.Add(pc);
            return true;
        }
        public bool Delete(string key)
        {
            int index = getProductCartIndex(key);
            if (index != -1)
            { 
                listPC.RemoveAt(index);
                return true;
            }
            return false;

       
        }
        public List<ProductCart> read()
        {
            return listPC;
        }

        public bool Update(string key, ProductCart pc)
        {
            
            if (key != pc.ProductCode)
            {
                return false;
            }
            
            int index = getProductCartIndex(key);
            if (index != -1)
            {
                listPC[index] = pc;
                return true;
            }
            return false;
        }

    }
}
