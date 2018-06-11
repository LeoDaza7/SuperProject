using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    class CartService
    {
        public List<Cart> ListC;
        public CartService()
        {
            ListC = new List<Cart>();
        }
        public bool create(string UserName, List<ProductCart> ListPC, List<User> UsersList)
        {
            foreach (User u in UsersList)
            {
                if (u.Username.Equals(UserName))
                {
                    Cart cart1 = new Cart();



                    cart1.Username = UserName;


                    foreach (Cart c in ListC)
                    {
                        if (c.Username.Equals(UserName))
                        {

                            return false;
                        }
                    }

                    cart1.ListPC = ListPC;

                    ListC.Add(cart1);
                    return true;

                }

            }
            return false;



        }
        public List<Cart> read()
        {
            Cart cart1 = new Cart() { Username = "Francisco", ListPC = new List<ProductCart>() };
            Cart cart2 = new Cart() { Username = "Francisco", ListPC = new List<ProductCart>() };
            Cart cart3 = new Cart() { Username = "Francisco", ListPC = new List<ProductCart>() };
            Cart cart4 = new Cart() { Username = "Francisco", ListPC = new List<ProductCart>() };
            Cart cart5 = new Cart() { Username = "Francisco", ListPC = new List<ProductCart>() };

            ListC.Add(cart1);
            ListC.Add(cart2);
            ListC.Add(cart3);
            ListC.Add(cart4);
            ListC.Add(cart5);
            return ListC;
        }
        public bool Update(string UserName, Cart cart)
        {
            foreach (Cart c in ListC)
            {
                if (c.Username.Equals(UserName))
                {
                    c.Username = cart.Username;
                    c.ListPC = cart.ListPC;

                    return true;
                }
            }
            return false;
        }
        public bool Delete(string UserName)
        {
            foreach (Cart c in ListC)
            {
                if (c.Username.Equals(UserName))
                {
                    ListC.Remove(c);
                    return true;
                }
            }
            return false;
        }
    }
}
