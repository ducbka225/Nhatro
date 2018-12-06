using DOANTOTNGHIEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class Admin_listProductController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();
        // GET: Admin_listProduct
        public ActionResult listProduct()
        {
            var listAll = (from p in db.Product
                           join pt in db.ProductType on p.IdProductType equals pt.Id
                           join s in db.Street on p.IdStreet equals s.Id
                           join dt in db.District on s.IdDistrict equals dt.Id
                           select new ProductModel
                           {
                               Id = p.Id,
                               Title = p.Title,
                               Acreage = p.Acreage,
                               Price = p.Price,
                               IsActive = p.IsActive,
                               ProducType = pt.Name,
                               District = dt.Name,
                               CreatedDate = p.CreatedDate,
                               Image = p.Image,
                           }).ToList();
            ViewBag.ListAll = listAll;
            return View();
        }
    }
}