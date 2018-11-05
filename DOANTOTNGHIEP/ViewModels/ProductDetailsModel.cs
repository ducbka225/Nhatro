using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOANTOTNGHIEP.ViewModels
{
    public class ProductDetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double? Acreage { get; set; }
        public double? Price { get; set; }
        public int? IsActive { get; set; }
        public int? Islevel { get; set; }
        public string ProducType { get; set; }
        public string District { get; set; }
        public string LocationName { get; set; }
        public double? Locationcode { get; set; }
        public string Description { get; set; }
        public int? Floor { get; set; }
        public string Sanitary { get; set; }
        public int? PeopleNum { get; set; }
        public double? PriceElectric { get; set; }
        public double? PriceWater { get; set; }
        public int? BedRoomNumber { get; set; }
        public string UserName { get; set; }
        public int? PhoneNumber { get; set; }

    }
}