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

            var product = db.Product.OrderByDescending(p => p.Id).FirstOrDefault();

            var image = (from i in db.Image
                         join p in db.Product on i.IdProduct equals p.Id
                         where p.Id == product.Id
                         select new ImageModel()
                         {
                             IdProduct = p.Id,
                             Link = i.Link,
                         }).ToList();

            ViewBag.User = user;
            ViewBag.Image = image;
            ViewBag.Product = product;
            return View();
        }

        // thanh toán
        [HttpPost]
        public JsonResult PostThanhToan(DateTime ExpireDate, float TotalPrice, int UserId, int IsLevel, string Image)
        {

            var result = false;
            var product = db.Product.OrderByDescending(p => p.Id).FirstOrDefault();
            var image = (from i in db.Image
                         where i.IdProduct == 5
                         select i).ToList();
            var user = (from u in db.User
                        where u.Id == UserId
                        select u).FirstOrDefault();
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
                productsave.Image = Image;
                db.SaveChanges();
                
                // RedirectToAction("ThanhToan", "ThanhToan", new { @Idproduct = _idProduct });

                // save in image
                foreach(Image item in image)
                {
                    item.IdProduct = product.Id;
                    db.SaveChanges();
                }
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