using DOANTOTNGHIEP.Models;
using DOANTOTNGHIEP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

        //Upload image
        //[HttpPost]
        //public JsonResult Upload(Picture picture)
        //{
        //    var result = true;
        //    foreach(var file in picture.Files)
        //    {
        //        if(file.ContentLength > 0)
        //        {
        //            var fileName = Path.GetFileName(file.FileName) + DateTime.Now.ToString("yyyymmddMMss");
        //            var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
        //            file.SaveAs(path);
        //            try
        //            {
        //                Image image = new Image();
        //                image.Link = "~/Content/images" + fileName;
        //                image.IdProduct = 5;
        //                db.Image.Add(image);
        //                db.SaveChanges();
        //            }
        //            catch
        //            {
        //                result = false;
        //            }
                    
        //        }             
        //    }
        //    return Json(new { result }, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult UploadFiles()
        {
            var result = "Upload fails";
            string path = Server.MapPath("~/Content/images/");
            HttpFileCollectionBase files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                file.SaveAs(path + file.FileName + DateTime.Now.ToString("yyyymmddMMss"));

                try
                {
                    Image image = new Image();
                    image.Link = "~/Content/images/" + file.FileName + DateTime.Now.ToString("yyyymmddMMss");
                    image.IdProduct = 5;
                    db.Image.Add(image);
                    db.SaveChanges();
                    result = files.Count + " Đã Upload!";
                }

                catch
                {
                    result = "Upload fails";
                }
                
            }
            return Json(result);
        }
    }
}