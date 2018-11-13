using DOANTOTNGHIEP.Models;
using DOANTOTNGHIEP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class DangTinController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();
        // GET: DangTin
        public ActionResult DangTin()
        {
            var User = Session["UserName"].ToString();
            if(User == null)
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult GetDistrict(int provinceid)
        {
            var dataResult = (from d in db.District
                              join p in db.Province on d.IdProvince equals p.Id
                              where p.Id == provinceid
                              select new DistrictModel
                              {
                                  Id = d.Id,
                                  Name = d.Name,
                              }).ToList();
            return Json(dataResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStreet(int districtId)
        {
            var dataResult = (from s in db.Street
                              join d in db.District on s.IdDistrict equals d.Id
                              where d.Id == districtId
                              select new StreetModel
                              {
                                  Id = s.Id,
                                  Name = s.Name,
                              }).ToList();
            return Json(dataResult, JsonRequestBehavior.AllowGet);
        }

        // đăng tin
        [HttpPost]
        public JsonResult DangTin(DangTinModel item)
        {
            var User = Session["UserName"].ToString();
            var result = false;
            if (ModelState.IsValid)
            {
                //save in Location
                Location location = new Location();
                location.Name = item.addressDetails;
                db.Location.Add(location);
                db.SaveChanges();

                var _idlocation = location.Id;

                // save in Product
                Product product = new Product();
                product.IdLocation = _idlocation;
                product.IdNeedFor = item.need;
                product.IdProductType = item.type;
                product.IdStreet = item.street;
                product.Acreage = item.acreage;
                product.Phone = item.phone;
                product.Owner = User;
                product.Title = item.title;
                product.Price = item.price;
                product.CreatedDate = DateTime.Now;
                db.Product.Add(product);
                db.SaveChanges();

                var _idProduct = product.Id;

                // save in ProductDetail
                ProductDetails productDetails = new ProductDetails();
                productDetails.IdProduct = _idProduct;
                productDetails.PeopleNum = item.numberPeople;
                productDetails.PriceElectric = item.priceElectric;
                productDetails.PriceWater = item.priceWater;
                productDetails.Floor = item.floor;
                productDetails.Sanitary = item.wc;
                productDetails.Description = item.description;
                db.ProductDetails.Add(productDetails);
                db.SaveChanges();

                result = true;
               // RedirectToAction("ThanhToan", "ThanhToan", new { @Idproduct = _idProduct });
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}