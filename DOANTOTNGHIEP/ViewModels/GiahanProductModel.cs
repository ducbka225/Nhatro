using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOANTOTNGHIEP.ViewModels
{
    public class GiahanProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Owner { get; set; }
        public int? Phone { get; set; }
        public double? Acreage { get; set; }
        public double? Price { get; set; }
    }
}