using DOANTOTNGHIEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class NapTienController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();
        // GET: NapTien
        public ActionResult NapTien()
        {
            return View();
        }

        // thanh toán
        [HttpPost]
        public JsonResult PostNapTien(string email, string seri, int balance, int menhgia, int type )
        {

            var result = false;

            
            if (ModelState.IsValid)
            {
                //save in Transaction
                var user = (from u in db.User
                            where u.Email == email
                            select u).FirstOrDefault();

                var card = (from c in db.Card
                            where c.Seri == seri && c.Type == type && c.menhgia == menhgia
                            select c).FirstOrDefault();

                if(card == null)
                {
                    result = false;
                }
                else
                {
                    //save User
                    User usersave = user;
                    usersave.Balance = user.Balance + menhgia;
                    db.SaveChanges();
                    result = true;
                }
                
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}