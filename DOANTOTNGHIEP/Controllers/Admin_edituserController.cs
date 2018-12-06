using DOANTOTNGHIEP.Models;
using DOANTOTNGHIEP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class Admin_edituserController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();
        // GET: Admin_edituser
        public ActionResult EditUser(int userid)
        {
            var user = (from u in db.User
                        where u.Id == userid
                        select u).FirstOrDefault();
            ViewBag.User = user;
            return View();
        }

        // sửa user
        [HttpPost]
        public JsonResult PostEditUser(AddUserModel item)
        {

            var result = false;
            if (ModelState.IsValid)
            {
                var user = (from u in db.User
                            where u.Id == item.userid
                            select u).FirstOrDefault();

                User usersave = user;
                usersave.LoginId = item.txtUser;
                usersave.Password = item.txtPass;
                usersave.IsActive = item.level;
                db.SaveChanges();

                result = true;


                // RedirectToAction("ThanhToan", "ThanhToan", new { @Idproduct = _idProduct });
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        //xóa user
        [HttpPost]
        public JsonResult Xoa(int userid)
        {

            var result = false;
            if (ModelState.IsValid)
            {
                var user = (from u in db.User
                            where u.Id == userid
                            select u).FirstOrDefault();


                db.User.Remove(user);
                db.SaveChanges();

                result = true;


                // RedirectToAction("ThanhToan", "ThanhToan", new { @Idproduct = _idProduct });
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}