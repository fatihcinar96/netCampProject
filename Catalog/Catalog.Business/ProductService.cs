using Catalog.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalog.Business
{
    public class ProductService
    {
        public dynamic GetList()
        {
            using (var db = new EFCoreContext())
            {
                var products = db.Products.Include("Brands").Include("Categories")
                    .Join(db.Brands, p => p.BrandID, b => b.BrandID, (p, b) => new { product = p, brand = b })
                    .Join(db.Categories, pc => pc.product.CategoryID, c => c.CategoryID, (pc, c) => new { product = pc, category = c })
                    .Select(x => new ProductListModel
                    {
                        ID = x.product.product.ID,
                        Name = x.product.product.Name,
                        BrandName = x.product.brand.Name,
                        CategoryName = x.category.Name,
                        Description = x.product.product.Description
                    });

                return products.ToList();
            }
        }

        public Product Add(Product model)
        {
            using (var db = new EFCoreContext())
            {
                db.Products.Add(model);
                db.SaveChanges();
                return model;
            }
        }

        public Product Update(Product model)
        {
            using (var db = new EFCoreContext())
            {
                db.Products.Update(model);
                db.SaveChanges();
                return model;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new EFCoreContext())
            {
                var model = db.Products.FirstOrDefault(x => x.ID == id);
                if(model == null)
                {
                    return false;
                }
                db.Products.Remove(model);
                db.SaveChanges();
                return true;
            }
        }

        public class ProductListModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string BrandName { get; set; }
            public string CategoryName { get; set; }
        }
    }
}
