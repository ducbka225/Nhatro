using DOANTOTNGHIEP.Models;
using DOANTOTNGHIEP.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class Admin_DashBoardController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();
        // GET: Admin_DashBoard
        public ActionResult DashBoard()
        {
            var tran = (from t in db.Transaction
                        let tp = t.TotalPrice
                        group tp by new {d = t.CreatedDate.Day } into gtp
                               select new TransactionModel()
                               {
                                   Id = gtp.Key.d,
                                   TotalPrice = gtp.Sum(),
                               }).ToList();
            ViewBag.DataPoints = JsonConvert.SerializeObject(tran);
            return View();
        }
    }
}