using DOANTOTNGHIEP.Models;
using DOANTOTNGHIEP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class GiaHanController : Controller
    {
        // GET: GiaHan
        NhaTroEntities db = new NhaTroEntities();
        public ActionResult GiaHan(int ProductId)
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

            var product = (from p in db.Product
                           where p.Id == ProductId
                           select new GiahanProductModel()
                           {
                               Id = p.Id,
                               Title = p.Title,
                               Acreage = p.Acreage,
                               Owner = p.Owner,
                               Phone = p.Phone,
                               Price = p.Price,

                           }).FirstOrDefault();

            ViewBag.User = user;
            ViewBag.Product = product;
            return View();
        }

        // thanh toán
        [HttpPost]
        public JsonResult PostThanhToan(DateTime ExpireDate, float TotalPrice, int UserId, int IsLevel, int IdProduct)
        {

            var result = false;
            var product = db.Product.Where(p => p.Id == IdProduct).FirstOrDefault();

            var user = (from u in db.User
                        where u.Id == UserId
                        select u).FirstOrDefault();
            if (ModelState.IsValid)
            {
                //save in Transaction
                var transactionbyproductid = db.Transaction.Where(p => p.IdProduct == IdProduct).FirstOrDefault();
                Transaction transaction = transactionbyproductid;
                transaction.CreatedDate = DateTime.Now;
                transaction.ExpireDate = ExpireDate;
                transaction.TotalPrice = TotalPrice;
                transaction.IdProduct = product.Id;
                transaction.IdUser = UserId;
                db.SaveChanges();

                // save in product
                Product productsave = product;
                productsave.IsActive = 1;
                productsave.IsLevel = IsLevel;
                db.SaveChanges();

                // RedirectToAction("ThanhToan", "ThanhToan", new { @Idproduct = _idProduct });
                result = true;

                //save User
                User usersave = user;
                usersave.Balance = user.Balance - TotalPrice;
                db.SaveChanges();
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}