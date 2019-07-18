using Catalog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalog.Business
{
    public class BrandService
    {
        public List<Brand> GetList()
        {
            using (var db = new EFCoreContext())
            {
                return db.Brands.ToList();
                
            }
        }

        public Brand Add(Brand model)
        {
            using (var db = new EFCoreContext())
            {
                db.Brands.Add(model);
                db.SaveChanges();
                return model;

            }
        }

        public Brand Update(Brand model)
        {
            using (var db = new EFCoreContext())
            {
                var brand = db.Brands.FirstOrDefault(x => x.BrandID == model.BrandID);
                brand.Name = model.Name;
                db.SaveChanges();
                return model;

            }
        }

        public bool Delete(int id)
        {
            using (var db = new EFCoreContext())
            {
                var model = db.Brands.FirstOrDefault(x=> x.BrandID == id);
                if (model == null)
                {
                    return false;
                }
                db.Brands.Remove(model);
                db.SaveChanges();
                return true;

            }
        }
    }
}
