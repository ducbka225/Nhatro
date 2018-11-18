using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOANTOTNGHIEP.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double? Acreage { get; set; }
        public double? Price { get; set; }
        public int? IsActive { get; set; }
        public int? Islevel { get; set; }
        public string ProducType { get; set; }
        public string District { get; set; }
        public string Image { get; set; }
    }
}