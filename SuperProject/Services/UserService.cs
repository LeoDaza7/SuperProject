using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    class UserService : IService1<User>
    {
        public List<User> users;
        public UserService()
        {
            users = new List<User>();
        }

        private int GetIndex(string key)
        {
            return users.FindIndex((x => x.Username == key));
        }

        private bool Verification(User u)
        {
            return users.Exists((x => x.Username == u.Username));
        }

        public bool Create(User user)
        {
            bool existe = false;
            if (!users.Contains(user))
            {
                users.Add(user);
                existe = true;
            }
            return existe;
        }
        public List<User> Read()
        {
            users.Add(new User { Username = "user1", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            users.Add(new User { Username = "user2", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            users.Add(new User { Username = "user3", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            users.Add(new User { Username = "user4", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            users.Add(new User { Username = "user5", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            return users;
        }
        public bool Update(string key, User user)
        {
            bool existe = true;
            if (!key.Equals(user.Username))
                existe = false;
            if (existe)
            {
                int index = GetIndex(key);
                if (index != -1)
                    users[index] = user;
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
                users.RemoveAt(index);
            else
                eliminado = false;
            return eliminado;
        }
    }
}
