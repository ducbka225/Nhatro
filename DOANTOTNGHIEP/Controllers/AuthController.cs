using DOANTOTNGHIEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string email, string password)
        {
            var result = false;
            if (ModelState.IsValid)
            {
                using (NhaTroEntities db = new NhaTroEntities())
                {
                    var obj = db.User.Where(a => a.Email == email && a.Password == password).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.LoginId.ToString();
                        Session["Email"] = obj.Email.ToString();
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                    
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult SignUp( User user)
        {
            var result = false;
            var checkEmail = true;
            if (ModelState.IsValid)
            {
                using (NhaTroEntities db = new NhaTroEntities())
                {
                    var userByEmail = (from u in db.User
                                       where u.Email == user.Email
                                       select u).FirstOrDefault();
                    if(userByEmail != null)
                    {
                        checkEmail = false;
                    }

                    else
                    {
                        try
                        {
                            User users = new User();
                            users.LoginId = user.LoginId;
                            users.Phone = user.Phone;
                            users.Email = user.Email;
                            users.Password = user.Password;
                            db.User.Add(users);
                            db.SaveChanges();
                            result = true;
                        }

                        catch
                        {
                            result = false;
                        }
                    }
                                   
                }
            }

            return Json( new { result, checkEmail }, JsonRequestBehavior.AllowGet);
        }
    }
}