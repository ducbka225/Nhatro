using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOANTOTNGHIEP.ViewModels
{
    public class AddProductModel
    {
        public int need { get; set; }
        public int type { get; set; }
        public int? phone { get; set; }
        public double? price { get; set; }
        public double? acreage { get; set; }
        public int province { get; set; }
        public int district { get; set; }
        public int street { get; set; }
        public string addressDetails { get; set; }
        public int? floor { get; set; }
        public string wc { get; set; }
        public int? numberPeople { get; set; }
        public double? priceElectric { get; set; }
        public double? priceWater { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string owner { get; set; }
        public int islevel { get; set; }
    }
}