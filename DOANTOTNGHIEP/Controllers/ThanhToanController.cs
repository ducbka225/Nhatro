using DOANTOTNGHIEP.Models;
using DOANTOTNGHIEP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class ThanhToanController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();
        // GET: ThanhToan
        public ActionResult ThanhToan()
        {
            var Email = Session["Email"].ToString();
            if (Email == null)
            {
                RedirectToAction("Index", "Home");
            }
            var user = (from u in db.User
                        where u.Email == Email
                        select new UserModel()
                        {
                            Id = u.Id,
                            Balance = u.Balance,
                        }).FirstOrDefault();

            ViewBag.User = user;
            return View();
        }

        // thanh toán
        [HttpPost]
        public JsonResult PostThanhToan(DateTime ExpireDate, float TotalPrice, int UserId, int IsLevel)
        {

            var result = false;
            var product = db.Product.OrderByDescending(p => p.Id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                //save in Transaction
                Transaction transaction = new Transaction();
                transaction.CreatedDate = DateTime.Now;
                transaction.ExpireDate = ExpireDate;
                transaction.TotalPrice = TotalPrice;
                transaction.IdProduct = product.Id;
                transaction.IdUser = UserId;
                db.Transaction.Add(transaction);
                db.SaveChanges();

                // save in product
                Product productsave = product;
                productsave.IsActive = 1;
                productsave.IsLevel = IsLevel;
                db.SaveChanges();
                result = true;
                // RedirectToAction("ThanhToan", "ThanhToan", new { @Idproduct = _idProduct });
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }


    }
}