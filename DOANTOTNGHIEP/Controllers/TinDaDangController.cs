using DOANTOTNGHIEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class TinDaDangController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();
        // GET: TinDaDang
        public ActionResult TinDaDang()
        {
            var email = Session["Email"].ToString();
            var user = (from u in db.User
                        where u.Email == email
                        select u).FirstOrDefault();
            ViewBag.User = user;
            var data = (from u in db.User
                        join t in db.Transaction on u.Id equals t.IdUser
                        join p in db.Product on t.IdProduct equals p.Id
                        where u.Email == email
                        select new ProductModel {
                            Id = p.Id,
                            Title = p.Title
                        }).ToList();
            ViewBag.User = user;
            ViewBag.Data = data;
            return View();
        }

        // Xóa tin
        [HttpPost]
        public ActionResult XoaTin(int ProductId)

        {
            if (ModelState.IsValid)
            {
                var product = (from p in db.Product
                            where p.Id == ProductId
                            select p).FirstOrDefault();
                db.Product.Remove(product);
                db.SaveChanges();
            }
            return View();
        }
    }
}