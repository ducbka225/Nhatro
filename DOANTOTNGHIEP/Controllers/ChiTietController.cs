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
            // get user
            //var Email = Session["Email"].ToString();
            //var user = (from u in db.User
            //            where u.Email == Email
            //            select new UserModel()
            //            {
            //                Id = u.Id,
            //                Balance = u.Balance,
            //            }).FirstOrDefault();        

            // get Image
            var image = (from i in db.Image
                         join p in db.Product on i.IdProduct equals p.Id
                         where p.Id == ProductId
                         select new ImageModel()
                         {
                             Link = i.Link,
                         }).ToList();
            // get details
            var details = (from p in db.Product
                           join pt in db.ProductType on p.IdProductType equals pt.Id
                           join s in db.Street on p.IdStreet equals s.Id
                           join dt in db.District on s.IdDistrict equals dt.Id
                           join pdt in db.ProductDetails on p.Id equals pdt.IdProduct
                           join l in db.Location on p.IdLocation equals l.Id
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
                               UserName = p.Owner,
                               PhoneNumber = p.Phone,
                               IdProduct = ProductId
                           }).FirstOrDefault();
            ViewBag.Details = details;
            ViewBag.Image = image;
            //ViewBag.User = user;
            return View();
        }

        // Lưu tin
        [HttpPost]
        public JsonResult LuuTin(string email, double priceluutin, int IdProduct)
        {
            var result = false;
            if (ModelState.IsValid)
            {
                var user = (from u in db.User
                            where u.Email == email
                            select u).FirstOrDefault();
                //save User
                User usersave = user;
                usersave.Balance = user.Balance - priceluutin;
                db.SaveChanges();

                SaveProduct saveProduct = new SaveProduct();
                saveProduct.IdUser = user.Id;
                saveProduct.IdProduct = IdProduct;
                db.SaveProduct.Add(saveProduct);
                db.SaveChanges();
                result = true;
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }


    }
}