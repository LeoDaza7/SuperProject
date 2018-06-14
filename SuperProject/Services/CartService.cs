using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    public class CartService : IService1<Cart>
    {
        public List<Cart> listC;
        public CartService()
        {
            listC = new List<Cart>();
        }
        private int GetIndex(string Username)
        {
            return listC.FindIndex((x => x.Username == Username));
        }

        private bool Verification(Cart c)
        {
            return listC.Exists((x => x.Username == c.Username));
        }

        public bool Create(Cart cart)
        {
            bool existe = !Verification(cart);
            if (existe)
            {
                listC.Add(cart);
            }
            return existe;
        }

        public List<Cart> Read()
        {
            Cart cart1 = new Cart() { Username = "Francisco", ListPC = new List<ProductCart>() };
            Cart cart2 = new Cart() { Username = "Francisco", ListPC = new List<ProductCart>() };
            Cart cart3 = new Cart() { Username = "Francisco", ListPC = new List<ProductCart>() };
            Cart cart4 = new Cart() { Username = "Francisco", ListPC = new List<ProductCart>() };
            Cart cart5 = new Cart() { Username = "Francisco", ListPC = new List<ProductCart>() };

            listC.Add(cart1);
            listC.Add(cart2);
            listC.Add(cart3);
            listC.Add(cart4);
            listC.Add(cart5);
            return listC;
        }

        public bool Update(string key, Cart cart)
        {
            bool existe = true;
            if (!key.Equals(cart.Username))
                existe = false;
            if (existe)
            {
                int index = GetIndex(key);
                if (index != -1)
                    listC[index] = cart;
                else
                    existe = false;
            }
            return existe;
        }

        public bool Delete(string key)
        {
            bool eliminado = true;
            int index = GetIndex(key);
            if (index != -1)
                listC.RemoveAt(index);
            else
                eliminado = false;
            return eliminado;
        }
    }
}
