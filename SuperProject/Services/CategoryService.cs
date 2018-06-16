﻿using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    public class CategoryService : IService1<Category>
    {
        public SuperDB instance;

        public CategoryService()
        {
            instance = SuperDB.Instance;
        }

        public int GetIndex(string key)
        {
            return instance.CategorysList.FindIndex((x => x.Name == key));
        }

        public bool Verification(Category c)
        {
            return instance.CategorysList.Exists((x => x.Name == c.Name));
        }
        public bool Create(Category category)
        {
            bool existe = !Verification(category);
            if (existe)
            {
                instance.CategorysList.Add(category);
            }
            return existe;
        }

        public List<Category> Read()
        {
            return instance.CategorysList;
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
                    instance.CategorysList[index] = uCategory;
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
                instance.CategorysList.RemoveAt(index);
            else
                eliminado = false;
            return eliminado;
        }
    }
}
