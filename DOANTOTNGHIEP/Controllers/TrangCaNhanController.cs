using DOANTOTNGHIEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class TrangCaNhanController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();
        // GET: TrangCaNhan
        public ActionResult TrangCaNhan()
        {
            var email = Session["Email"];
            var user = (from u in db.User
                        where u.Email == email
                        select u).FirstOrDefault();
            ViewBag.User = user;
            return View();
        }
    }
}