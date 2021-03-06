﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOANTOTNGHIEP.Models;

namespace DOANTOTNGHIEP.Controllers
{
    public class HomeController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();

        public ActionResult Index()
        {
            // list all
            var listAll = (from p in db.Product
                           join pt in db.ProductType on p.IdProductType equals pt.Id
                           join s in db.Street on p.IdStreet equals s.Id
                           join dt in db.District on s.IdDistrict equals dt.Id
                           where p.IsActive == 1 && p.IsLevel == 2
                           select new ProductModel
                           {
                               Id = p.Id,
                               Title = p.Title,
                               Acreage = p.Acreage,
                               Price = p.Price,
                               IsActive = p.IsActive,
                               Islevel = p.IsLevel,
                               ProducType = pt.Name,
                               District = dt.Name,
                               Image = p.Image,
                           }).ToList();
            ViewBag.ListAll = listAll;

            //list nhà trọ, phòng trọ
            var NhaTro = (from p in db.Product
                           join pt in db.ProductType on p.IdProductType equals pt.Id
                           join s in db.Street on p.IdStreet equals s.Id
                           join dt in db.District on s.IdDistrict equals dt.Id
                          where p.IsActive == 1 && pt.Id == 1 && p.IsLevel == 2
                          select new ProductModel
                           {
                               Id = p.Id,
                               Title = p.Title,
                               Acreage = p.Acreage,
                               Price = p.Price,
                               IsActive = p.IsActive,
                               Islevel = p.IsLevel,
                               ProducType = pt.Name,
                               District = dt.Name,
                               Image = p.Image
                           }).ToList();
            ViewBag.NhaTro = NhaTro;

            // List Nhà nguyên căn
            var NhaNguyencan = (from p in db.Product
                          join pt in db.ProductType on p.IdProductType equals pt.Id
                          join s in db.Street on p.IdStreet equals s.Id
                          join dt in db.District on s.IdDistrict equals dt.Id
                            where p.IsActive == 1 && pt.Id == 4 && p.IsLevel == 2
                                select new ProductModel
                          {
                              Id = p.Id,
                              Title = p.Title,
                              Acreage = p.Acreage,
                              Price = p.Price,
                              IsActive = p.IsActive,
                              Islevel = p.IsLevel,
                              ProducType = pt.Name,
                              District = dt.Name,
                              Image = p.Image
                          }).ToList();
            ViewBag.NhaNguyencan = NhaNguyencan;

            //list Văn phòng
            var VanPhong = (from p in db.Product
                          join pt in db.ProductType on p.IdProductType equals pt.Id
                          join s in db.Street on p.IdStreet equals s.Id
                          join dt in db.District on s.IdDistrict equals dt.Id
                            where p.IsActive == 1 && pt.Id == 5 && p.IsLevel == 2
                            select new ProductModel
                          {
                              Id = p.Id,
                              Title = p.Title,
                              Acreage = p.Acreage,
                              Price = p.Price,
                              IsActive = p.IsActive,
                              Islevel = p.IsLevel,
                              ProducType = pt.Name,
                              District = dt.Name,
                              Image = p.Image
                          }).ToList();
            ViewBag.VanPhong = VanPhong;

            //list chung cư
            var ChungCu = (from p in db.Product
                          join pt in db.ProductType on p.IdProductType equals pt.Id
                          join s in db.Street on p.IdStreet equals s.Id
                          join dt in db.District on s.IdDistrict equals dt.Id
                           where p.IsActive == 1 && pt.Id == 3 && p.IsLevel == 2
                           select new ProductModel
                          {
                              Id = p.Id,
                              Title = p.Title,
                              Acreage = p.Acreage,
                              Price = p.Price,
                              IsActive = p.IsActive,
                              Islevel = p.IsLevel,
                              ProducType = pt.Name,
                              District = dt.Name,
                              Image = p.Image
                          }).ToList();
            ViewBag.ChungCu = ChungCu;
            return View();
        }
    }
}