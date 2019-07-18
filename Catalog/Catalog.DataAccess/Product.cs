using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DataAccess
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }
    }
}
