using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    class UserService
    {
        public List<User> users;
        public UserService()
        {
            users = new List<User>();
        }
        public bool create(String Username, String Password, String Name, String LastName, List<ShippingAddress> ShippingAddresses)
        {
            User user = new User();
            user.Username = Username;
            user.Password = Password;
            user.Name = Name;
            user.LastName = LastName;
            user.ShippingAddresses = ShippingAddresses;
            if (!users.Contains(user))
            {
                users.Add(user);
                return true;
            }
            else
            {
                Console.WriteLine("This username already exists.");
                return false;
            }
            
        }
        public List<User> read()
        {
            users.Add(new User { Username = "user1", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            users.Add(new User { Username = "user2", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            users.Add(new User { Username = "user3", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            users.Add(new User { Username = "user4", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            users.Add(new User { Username = "user5", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            return users;
        }
        public bool Update(User user, String Username, String Password, String Name, String LastName, List<ShippingAddress> ShippingAddresses)
        {
            if (users.Contains(user))
            {
                users.Remove(user);
                create(Username, Password, Name, LastName, ShippingAddresses);
                return true;
            }
            else
            {
                Console.WriteLine("This user doesn't exists or can't be updated.");
                return false;
            }
        }
        public bool Delete(User user)
        {
            if (users.Contains(user))
            {
                users.Remove(user);
                return true;
            }
            else
            {
                Console.WriteLine("This user doesn't exists or can't be deleted.");
                return false;
            }
        }
    }
}
