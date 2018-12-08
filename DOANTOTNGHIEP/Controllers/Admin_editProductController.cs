using DOANTOTNGHIEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class Admin_editProductController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();
        // GET: Admin_editProduct
        public ActionResult editProduct(int productid)
        {
            var listAll = (from p in db.Product
                           join pt in db.ProductType on p.IdProductType equals pt.Id
                           join s in db.Street on p.IdStreet equals s.Id
                           join dt in db.District on s.IdDistrict equals dt.Id
                           where p.Id == productid
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
                               Islevel = p.IsLevel,
                           }).FirstOrDefault();

            //Session["ProducId"] = Convert.ToInt32(productid.ToString());
            ViewBag.ListAll = listAll;
            return View();
        }

        // sửa products
        [HttpPost]
        public JsonResult PostEditProduct(ProductModel item)
        {
           // var productid = Convert.ToInt32(Session["ProducId"].ToString());
            var result = false;
            if (ModelState.IsValid)
            {
                var product = (from p in db.Product
                            where p.Id == item.Id
                               select p).FirstOrDefault();

                Product productsave = product;
                productsave.Title = item.Title;
                productsave.Acreage = item.Acreage;
                productsave.Price = item.Price;
                productsave.IsLevel = item.Islevel;
                db.SaveChanges();

                result = true;


                // RedirectToAction("ThanhToan", "ThanhToan", new { @Idproduct = _idProduct });
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        //xóa product
        [HttpPost]
        public JsonResult Xoa(int productid)
        {

            var result = false;
            if (ModelState.IsValid)
            {
                var product = (from p in db.Product
                            where p.Id == productid
                            select p).FirstOrDefault();

                product.IsActive = 0;
                db.SaveChanges();

                result = true;


                // RedirectToAction("ThanhToan", "ThanhToan", new { @Idproduct = _idProduct });
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}