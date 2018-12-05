using DOANTOTNGHIEP.Models;
using DOANTOTNGHIEP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class ListUserController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();
        // GET: ListUser
        public ActionResult ListUser()
        {
            var listuser = (from u in db.User
                            select new UserModel
                            {
                                Id = u.Id,
                                Phone = u.Phone,
                                Email = u.Email,
                                LoginId = u.LoginId,
                                Balance = u.Balance,
                                Admin = u.IsActive,
                            }).ToList();
            ViewBag.User = listuser;
            return View();
        }
    }
}