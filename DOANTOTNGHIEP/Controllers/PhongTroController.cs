using DOANTOTNGHIEP.Models;
using DOANTOTNGHIEP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class PhongTroController : Controller
    {
        NhaTroEntities db = new NhaTroEntities(); 

        public ActionResult PhongTro(int ProductTypeId)
        {
            var productType = (from pt in db.ProductType
                               where pt.Id == ProductTypeId
                               select new ProductTypeModel()
                               {
                                   Name = pt.Name
                               }).FirstOrDefault();

            var Product = (from p in db.Product
                          join pt in db.ProductType on p.IdProductType equals pt.Id
                          join s in db.Street on p.IdStreet equals s.Id
                          join dt in db.District on s.IdDistrict equals dt.Id
                          where p.IsActive == 1 && pt.Id == ProductTypeId
                           select new ProductModel
                          {
                              Id = p.Id,
                              Title = p.Title,
                              Acreage = p.Acreage,
                              Price = p.Price,
                              IsActive = p.IsActive,
                              Islevel = p.IsLevel,
                              ProducType = pt.Name,
                              District = dt.Name,
                          }).ToList();

            ViewBag.ProductType = productType;
            ViewBag.Product = Product;

            return View();
        }
    }
}