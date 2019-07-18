using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Catalog.DataAccess
{
   public class Brand
    {
        public int BrandID { get; set; }
        public string Name { get; set; }
    }
}
