using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperProject.Services
{
   public class ProductCartService : IService1<ProductCart>
    {
        public List<ProductCart> listPC;
        public ProductCartService() { 
        }
        public int GetProductCartIndex(string productCode)
        {
            return listPC.FindIndex((x => x.ProductCode == productCode));
        }

        public bool ProductCartVerification(ProductCart pc)
        {
            return listPC.Exists((x => x.ProductCode == pc.ProductCode));
        }


        public bool Create(ProductCart pc)
        {
            bool existe = !ProductCartVerification(pc);
            if (existe)
            {
                if (pc.ShippingDeliveryType != ProductCart.shippingDeliveryTypeEnum.inStore)
                    pc.Store = null;
                listPC.Add(pc);
            }
            return existe;
        }
        public bool Delete(string key)
        {
            bool eliminado = true;
            int index = GetProductCartIndex(key);
            if (index != -1)
                listPC.RemoveAt(index);
            else
                eliminado = false;
            return eliminado;
        }
        public List<ProductCart> Read()
        {
            return listPC;
        }

        public bool Update(string key, ProductCart pc)
        {
            bool existe = true;
            if (!key.Equals(pc.ProductCode))
                existe = false;
            if (existe)
            {
                int index = GetProductCartIndex(key);
                if (index != -1)
                    listPC[index] = pc;
                else
                    existe = false;
            }
            return existe;
        }

    }
}
