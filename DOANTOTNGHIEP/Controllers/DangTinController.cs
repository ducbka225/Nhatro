using DOANTOTNGHIEP.Models;
using DOANTOTNGHIEP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class DangTinController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();
        // GET: DangTin
        public ActionResult DangTin()
        {
            return View();
        }

        public ActionResult GetDistrict(int provinceid)
        {
            var dataResult = (from d in db.District
                              join p in db.Province on d.IdProvince equals p.Id
                              where p.Id == provinceid
                              select new DistrictModel
                              {
                                  Id = d.Id,
                                  Name = d.Name,
                              }).ToList();
            return Json(dataResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStreet(int districtId)
        {
            var dataResult = (from s in db.Street
                              join d in db.District on s.IdDistrict equals d.Id
                              where d.Id == districtId
                              select new StreetModel
                              {
                                  Id = s.Id,
                                  Name = s.Name,
                              }).ToList();
            return Json(dataResult, JsonRequestBehavior.AllowGet);
        }
    }
}