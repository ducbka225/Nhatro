using DOANTOTNGHIEP.Models;
using DOANTOTNGHIEP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class ChiTietController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();
        // GET: ChiTiet
        public ActionResult ChiTiet(int ProductId)
        {
            var details = (from p in db.Product
                           join pt in db.ProductType on p.IdProductType equals pt.Id
                           join s in db.Street on p.IdStreet equals s.Id
                           join dt in db.District on s.IdDistrict equals dt.Id
                           join pdt in db.ProductDetails on p.Id equals pdt.IdProduct
                           join l in db.Location on p.IdLocation equals l.Id
                           join t in db.Transaction on p.Id equals t.IdProduct
                           join u in db.User on t.IdUser equals u.Id
                           where p.Id == ProductId
                           select new ProductDetailsModel()
                           {
                               Id = pdt.Id,
                               Title = p.Title,
                               Acreage = p.Acreage,
                               Price = p.Price,
                               IsActive = p.IsActive,
                               Islevel = p.IsLevel,
                               ProducType = pt.Name,
                               District = dt.Name,
                               LocationName = l.Name,
                               Locationcode = l.Location1,
                               Description = pdt.Description,
                               Floor = pdt.Floor,
                               Sanitary = pdt.Sanitary,
                               PeopleNum = pdt.PeopleNum,
                               PriceElectric = pdt.PriceElectric,
                               PriceWater = pdt.PriceWater,
                               BedRoomNumber = pdt.BedRoomNumber,
                               UserName = u.LoginId,
                               PhoneNumber = u.Phone,                             
                           }).FirstOrDefault();
            ViewBag.Details = details;
            return View();
        }
    }
}