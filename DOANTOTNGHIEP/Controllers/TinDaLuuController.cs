using DOANTOTNGHIEP.Models;
using DOANTOTNGHIEP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class TinDaLuuController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();
        // GET: TinDaLuu
        public ActionResult TinDaLuu()
        {
            var email = Session["Email"].ToString();
            var user = (from u in db.User
                        where u.Email == email
                        select u).FirstOrDefault();
            ViewBag.User = user;
            var data = (from u in db.User
                        join s in db.SaveProduct on u.Id equals s.IdUser
                        join p in db.Product on s.IdProduct equals p.Id
                        where u.Email == email
                        select new SaveProductModel
                        {
                            Id = s.Id,
                            IdProduct = p.Id,
                            Title = p.Title,
                            Phone = p.Phone,
                        }).ToList();
            ViewBag.User = user;
            ViewBag.Data = data;
            return View();
        }


        // Xóa tin
        [HttpPost]
        public JsonResult XoaTin(int ProductId)

        {
            var result = false;
            if (ModelState.IsValid)
            {
                var saveProduct = (from s in db.SaveProduct
                               where s.Id == ProductId
                               select s).FirstOrDefault();
                db.SaveProduct.Remove(saveProduct);
                db.SaveChanges();
                result = true;
            }
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}