using DOANTOTNGHIEP.Models;
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
                        select new ProductModel
                        {
                            Id = p.Id,
                            Title = p.Title
                        }).ToList();
            ViewBag.User = user;
            ViewBag.Data = data;
            return View();
        }
    }
}