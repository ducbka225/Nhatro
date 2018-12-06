using DOANTOTNGHIEP.Models;
using DOANTOTNGHIEP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class Admin_addProductController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();
        // GET: Admin_addProduct
        public ActionResult addProduct()
        {
            return View();
        }

        // đăng tin
        [HttpPost]
        public JsonResult DangTin(AddProductModel item)
        {

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
                product.Owner = item.owner;
                product.Title = item.title;
                product.Price = item.price;
                product.CreatedDate = DateTime.Now;
                product.IsLevel = item.islevel;
                product.IdNeedFor = 1;
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