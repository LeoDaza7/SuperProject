using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperProject.Services
{
   class ProductCartService
    {
        public Cart cart;
        public ProductCartService() { 
        }
        public ProductCartService(Cart cart)
        {
            this.cart = cart;
        }
        private int getProductCartIndex(string productCode)
        {
            return cart.ListPC.FindIndex((x => x.ProductCode == productCode));
        }

        public bool productCartVerification(ProductCart pc)
        {
            return cart.ListPC.Exists((x => x.ProductCode == pc.ProductCode));
        }


        public bool create(ProductCart pc)
        {
            if (productCartVerification(pc))
            {
                return false;
            }

            cart.ListPC.Add(pc);
            return true;
        }
        public bool Delete(string key)
        {
            int index = getProductCartIndex(key);
            if (index != -1)
            { 
                cart.ListPC.RemoveAt(index);
                return true;
            }
            return false;

       
        }
        public List<ProductCart> read()
        {
            return cart.ListPC;
        }

        public bool Update(string key, ProductCart pc)
        {
            
            if (key != pc.ProductCode || cart == null)
            {
                return false;
            }
            
            int index = getProductCartIndex(key);
            if (index != -1)
            {
                cart.ListPC[index] = pc;
                return true;
            }
            return false;
        }

    }
}
