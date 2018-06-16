using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    public class CategoryService : IService1<Category>
    {
        public List<Category> categoryList;

        public CategoryService()
        {
            categoryList = new List<Category>();
        }

        public int GetIndex(string key)
        {
            return categoryList.FindIndex((x => x.Name == key));
        }

        public bool Verification(Category c)
        {
            return categoryList.Exists((x => x.Name == c.Name));
        }
        public bool Create(Category category)
        {
            bool existe = !Verification(category);
            if (existe)
            {
                categoryList.Add(category);
            }
            return existe;
        }

        public List<Category> Read()
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
            bool exist = true;
            if (!key.Equals(uCategory.Name))
                exist = false;
            if (exist)
            {
                int index = GetIndex(key);
                if (index != -1)
                    categoryList[index] = uCategory;
                else
                    exist = false;
            }
            return exist;
        }

        public bool Delete(string key)
        {
            bool eliminado = true;
            int index = GetIndex(key);
            if (index != -1)
                categoryList.RemoveAt(index);
            else
                eliminado = false;
            return eliminado;
        }
    }
}
