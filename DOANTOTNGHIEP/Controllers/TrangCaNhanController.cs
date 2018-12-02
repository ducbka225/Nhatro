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
            var email = Session["Email"].ToString();
            var user = (from u in db.User
                        where u.Email == email
                        select u).FirstOrDefault();
            ViewBag.User = user;
            return View();
        }

        // Cập nhât
        [HttpPost]
        public JsonResult Update( string loginId, DateTime dateOfBirth, int phone, string address)
                               
        {
            var User = Session["Email"].ToString();
            var result = false;
            if (ModelState.IsValid)
            {
                var user = (from u in db.User
                             where u.Email == User
                             select u).FirstOrDefault();

                user.DateOfBirth = dateOfBirth;
                user.LoginId = loginId;
                user.Phone = phone;
                user.Address = address;
                db.SaveChanges();
                result = true;
               
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        // Đổi pass
        [HttpPost]
        public JsonResult ChangePass(string passwordnew)

        {
            var User = Session["Email"].ToString();
            var result = false;
            if (ModelState.IsValid)
            {
                var user = (from u in db.User
                            where u.Email == User
                            select u).FirstOrDefault();

                user.Password = passwordnew;
                db.SaveChanges();
                result = true;

            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}