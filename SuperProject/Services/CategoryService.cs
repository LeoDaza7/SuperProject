using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    class CategoryService
    {
        public List<Category> categoryList;

        public CategoryService()
        {
            if (categoryList){
                categoryList = new List<Category>();
            }
            
        }

        public bool create(string name, string description)
        {
            foreach (Category c in categoryList)
            {
                if (c.name == name)
                {
                    console.log("Name repeated or already exist!");
                    return false;
                }
            }
            Category nCategory = new Category();
            nCategory.Name = name;
            nCategory.Description = description;
            categoryList.Add(nCategory);
            return true;
        }

        public List<Category> read()
        {
            Category mock1 = new Category() {Name = "New", Description = "Not Used"};
            Category mock2 = new Category() {Name = "Not so new", Description = "Slightly Used"};
            Category mock3 = new Category() {Name = "Old", Description = "Used"};
            Category mock4 = new Category() {Name = "Rounded", Description = "Without Corners"};
            Category mock5 = new Category() {Name = "Squared", Description = "Without Curves"};
            categoryList.Add(mock1);
            categoryList.Add(mock2);
            categoryList.Add(mock3);
            categoryList.Add(mock4);
            categoryList.Add(mock5);

            return categoryList;
        }

        public bool Update(string key, Category uCategory)
        {
            foreach (Category c in categoryList)
            {
                if (c.name == key)
                {
                    console.log("Updating");
                    c.Name = uCategory.Name;
                    c.Description = uCategory.Description;
                    return true;
                }
            }
            console.log("Ups, seems like that category doesn't exist");
            return false;
        }

        public bool Delete(string key)
        {
            foreach (Category c in categoryList)
            {
                if (c.name == key)
                {
                    console.log("Exterminating!!!");
                    categoryList.Remove(c);
                    return true;
                }
            }
            console.log("Ups, seems like that category doesn't exist or is indestructible");
            return false;
        }
    }
}
