using DOANTOTNGHIEP.Models;
using DOANTOTNGHIEP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class ListImageController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();
        // GET: ListImage
        public ActionResult Image( int productid )
        {
            var image = (from i in db.Image
                         join p in db.Product on i.IdProduct equals p.Id
                         where p.Id == productid
                         select new ImageModel()
                         {
                             IdProduct = p.Id,
                             Link = i.Link,
                         }).ToList();
            Session["ProducId"] = Convert.ToInt32(productid.ToString());
            ViewBag.Image = image;
            return View();
        }

        [HttpPost]
        public ActionResult UploadFiles()
        {
            var productid = Convert.ToInt32(Session["ProducId"].ToString());
            var result = "Upload fails";
            string path = Server.MapPath("~/Content/images/");
            HttpFileCollectionBase files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                file.SaveAs(path + DateTime.Now.ToString("yyyymmddMMss") + file.FileName);

                try
                {
                    Image image = new Image();
                    image.Link = DateTime.Now.ToString("yyyymmddMMss") + file.FileName;
                    image.IdProduct = productid;
                    db.Image.Add(image);
                    db.SaveChanges();
                    result = " Đã Upload " + files.Count + "Ảnh";
                }

                catch
                {
                    result = "Upload fails";
                }

            }
            return Json(result);
        }

        //xóa ảnh
        [HttpPost]
        public JsonResult Xoa(string Link)
        {

            var result = false;
            if (ModelState.IsValid)
            {
                var Image = (from i in db.Image
                            where i.Link == Link
                            select i).FirstOrDefault();


                db.Image.Remove(Image);
                db.SaveChanges();

                result = true;


                // RedirectToAction("ThanhToan", "ThanhToan", new { @Idproduct = _idProduct });
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        //Set ảnh đại diện
        [HttpPost]
        public JsonResult SetImage(string Link)
        {
            var productid = Convert.ToInt32(Session["ProducId"].ToString());
            var result = false;
            if (ModelState.IsValid)
            {
                var product = db.Product.Where(p => p.Id == productid).FirstOrDefault();
                // save in product
                Product productsave = product;
                productsave.Image = Link;
                db.SaveChanges();

                result = true;


                // RedirectToAction("ThanhToan", "ThanhToan", new { @Idproduct = _idProduct });
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}