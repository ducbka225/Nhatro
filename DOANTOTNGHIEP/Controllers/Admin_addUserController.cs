using DOANTOTNGHIEP.Models;
using DOANTOTNGHIEP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class Admin_addUserController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();
        // GET: Admin_addUser
        public ActionResult addUser()
        {
            return View();
        }

        // đăng tin
        [HttpPost]
        public JsonResult ThemUser(AddUserModel item)
        {

            var result = false;
            if (ModelState.IsValid)
            {
                var userByEmail = (from u in db.User
                                   where u.Email == item.txtEmail
                                   select u).FirstOrDefault();
                if (userByEmail != null)
                {
                    result = false;
                }
                else
                {
                    User user = new User();
                    user.Email = item.txtEmail;
                    user.LoginId = item.txtUser;
                    user.Password = item.txtPass;
                    user.IsActive = item.level;
                    user.Balance = 0;

                    db.User.Add(user);
                    db.SaveChanges();

                    result = true;
                }
                
                // RedirectToAction("ThanhToan", "ThanhToan", new { @Idproduct = _idProduct });
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}