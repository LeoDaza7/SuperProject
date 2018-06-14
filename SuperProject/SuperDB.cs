using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperProject
{
    class SuperDB
    {
        private static SuperDB _instance;

        private SuperDB() {
            this.CartsList = new List<Cart>();
            this.CategorysList = new List<Category>();
            this.ProductsList = new List<Product>();
            this.StoresList = new List<Store>();
            this.UsersList = new List<User>();
        }

        public static SuperDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SuperDB();
                }
                return _instance;
            }
        }

        public List<Cart> CartsList { get; private set; }
        public List<Category> CategorysList { get; private set; }
        public List<Product> ProductsList { get; private set; }
        public List<ShippingAddress> ShippingAddressesList { get; private set; }
        public List<Store> StoresList { get; private set; }
        public List<User> UsersList { get; private set; }

    }
}
