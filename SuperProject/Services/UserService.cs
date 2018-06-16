﻿using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    public class UserService : IService1<User>
    {
        public SuperDB instance;
        public UserService()
        {
            instance = SuperDB.Instance;
        }

        public int GetIndex(string key)
        {
            return instance.UsersList.FindIndex((x => x.Username == key));
        }

        public bool Verification(User u)
        {
            return instance.UsersList.Exists((x => x.Username == u.Username));
        }

        public bool Create(User user)
        {
            bool existe = false;
            if (!instance.UsersList.Contains(user))
            {
                instance.UsersList.Add(user);
                existe = true;
            }
            return existe;
        }
        public List<User> Read()
        {
            instance.UsersList.Add(new User { Username = "user1", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            instance.UsersList.Add(new User { Username = "user2", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            instance.UsersList.Add(new User { Username = "user3", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            instance.UsersList.Add(new User { Username = "user4", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            instance.UsersList.Add(new User { Username = "user5", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            return instance.UsersList;
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
                    instance.UsersList[index] = user;
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
                instance.UsersList.RemoveAt(index);
            else
                eliminado = false;
            return eliminado;
        }
    }
}
