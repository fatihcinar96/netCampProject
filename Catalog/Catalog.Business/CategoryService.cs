﻿using Catalog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalog.Business
{
    public class CategoryService
    {
        public List<Category> GetList()
        {
            using(var db = new EFCoreContext())
            {
                return db.Categories.ToList();
            }
        }

        public Category GetCategory(int id)
        {
            using (var db = new EFCoreContext())
            {
                var model = db.Categories.Find(id);
                return model;
            }
        }

        public Category Add(Category model)
        {
            using(var db = new EFCoreContext())
            {
                db.Categories.Add(model);
                db.SaveChanges();
                return model;

            }
        }

        public Category Update (Category model)
        {
            using(var db = new EFCoreContext())
            {
                var category = db.Categories.Find(model.CategoryID);
                if(category != null)
                {

                    category.Name = model.Name;
                    db.SaveChanges();
                }
                return model;
            }
        }


        public bool Delete (int id)
        {
            using(var db = new EFCoreContext())
            {
                var model = db.Categories.FirstOrDefault(x => x.CategoryID == id);
                if(model == null)
                {
                    return false;
                }
                db.Categories.Remove(model);
                db.SaveChanges();
                return true;
            }
        }
    }
}
