using DOANTOTNGHIEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: Login
        public ActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        public JsonResult PostLoginAdmin(string email, string password)
        {
            var result = false;
            if (ModelState.IsValid)
            {
                using (NhaTroEntities db = new NhaTroEntities())
                {
                    var obj = db.Admin.Where(a => a.Email == email && a.Password == password).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["AdminID"] = Convert.ToInt32(obj.Id.ToString());
                        Session["AdminName"] = obj.Name.ToString();
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
            Session["AdminID"] = null;
            Session["AdminName"] = null;
            Session["Email"] = null;
            return RedirectToAction("LoginAdmin", "LoginAdmin");
        }
    }
}