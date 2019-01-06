using DOANTOTNGHIEP.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class Search1Controller : Controller
    {

        NhaTroEntities db = new NhaTroEntities();
        // GET: Search
        [HttpPost]
        public ActionResult Search1(FormCollection f, int? Page)
        {
            string prv = f["province1"].ToString();
            int province = Convert.ToInt32(prv);
            string dst = f["district1"].ToString();
            int district = Convert.ToInt32(dst);
            string sdt = f["dientich1"].ToString();
            int dientich = Convert.ToInt32(sdt);
            string pr = f["price1"].ToString();
            double price = Convert.ToDouble(pr);

            if (dientich == 1 && price == 1)
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1 && pv.Id == province && dt.Id == district && p.Acreage <= 20 && p.Price < 2000000
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
                                         CreatedDate = p.CreatedDate,
                                     }).ToList();

                // phân trang
                int pageNumber = (Page ?? 1);
                int pageSize = 6;
                if (productResult.Count == 0)
                {
                    ViewBag.Message = "Không tìm thấy!";
                }
                ViewBag.Product = productResult.OrderByDescending(x => x.Id).ToPagedList(pageNumber, pageSize);
            }

            else if (dientich == 1 && price == 2)
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1 && pv.Id == province && dt.Id == district && p.Acreage <= 20 && p.Price <= 5000000 && p.Price >= 2000000
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
                                         CreatedDate = p.CreatedDate,
                                     }).ToList();

                // phân trang
                int pageNumber = (Page ?? 1);
                int pageSize = 6;
                if (productResult.Count == 0)
                {
                    ViewBag.Message = "Không tìm thấy!";
                }
                ViewBag.Product = productResult.OrderByDescending(x => x.Id).ToPagedList(pageNumber, pageSize);
            }

            else if (dientich == 1 && price == 3)
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1 && pv.Id == province && dt.Id == district && p.Acreage <= 20 && p.Price > 5000000
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
                                         CreatedDate = p.CreatedDate,
                                     }).ToList();

                // phân trang
                int pageNumber = (Page ?? 1);
                int pageSize = 6;
                if (productResult.Count == 0)
                {
                    ViewBag.Message = "Không tìm thấy!";
                }
                ViewBag.Product = productResult.OrderByDescending(x => x.Id).ToPagedList(pageNumber, pageSize);
            }

            else if (dientich == 2 && price == 1)
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1  && pv.Id == province && dt.Id == district && 20 <= p.Acreage && p.Acreage <= 30 && p.Price < 2000000
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
                                         CreatedDate = p.CreatedDate,
                                     }).ToList();

                // phân trang
                int pageNumber = (Page ?? 1);
                int pageSize = 6;
                if (productResult.Count == 0)
                {
                    ViewBag.Message = "Không tìm thấy!";
                }
                ViewBag.Product = productResult.OrderByDescending(x => x.Id).ToPagedList(pageNumber, pageSize);
            }

            else if (dientich == 2  && price == 2)
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1 && pv.Id == province && dt.Id == district && 20 <= p.Acreage && p.Acreage <= 30 && p.Price <= 5000000 && p.Price >= 2000000
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
                                         CreatedDate = p.CreatedDate,
                                     }).ToList();

                // phân trang
                int pageNumber = (Page ?? 1);
                int pageSize = 6;
                if (productResult.Count == 0)
                {
                    ViewBag.Message = "Không tìm thấy!";
                }
                ViewBag.Product = productResult.OrderByDescending(x => x.Id).ToPagedList(pageNumber, pageSize);
            }

            else if (dientich == 2 && price == 3)
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1 && pv.Id == province && dt.Id == district && 20 <= p.Acreage && p.Acreage <= 30 && p.Price > 5000000
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
                                         CreatedDate = p.CreatedDate,
                                     }).ToList();
                // phân trang
                int pageNumber = (Page ?? 1);
                int pageSize = 6;
                if (productResult.Count == 0)
                {
                    ViewBag.Message = "Không tìm thấy!";
                }
                ViewBag.Product = productResult.OrderByDescending(x => x.Id).ToPagedList(pageNumber, pageSize);
            }

            else if (dientich == 3 && price == 1)
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1 && pv.Id == province && dt.Id == district && 30 <= p.Acreage && p.Price < 2000000
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
                                         CreatedDate = p.CreatedDate,
                                     }).ToList();

                // phân trang
                int pageNumber = (Page ?? 1);
                int pageSize = 6;
                if (productResult.Count == 0)
                {
                    ViewBag.Message = "Không tìm thấy!";
                }
                ViewBag.Product = productResult.OrderByDescending(x => x.Id).ToPagedList(pageNumber, pageSize);
            }

            else if (dientich == 3 && price == 2)
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1 && pv.Id == province && dt.Id == district && 30 <= p.Acreage && p.Price <= 5000000 && p.Price >= 2000000
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
                                         CreatedDate = p.CreatedDate,
                                     }).ToList();

                // phân trang
                int pageNumber = (Page ?? 1);
                int pageSize = 6;
                if (productResult.Count == 0)
                {
                    ViewBag.Message = "Không tìm thấy!";
                }
                ViewBag.Product = productResult.OrderByDescending(x => x.Id).ToPagedList(pageNumber, pageSize);
            }

            else if (dientich == 3 && price == 3)
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1 && pv.Id == province && dt.Id == district && 30 <= p.Acreage && p.Price > 5000000
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
                                         CreatedDate = p.CreatedDate,
                                     }).ToList();

                // phân trang
                int pageNumber = (Page ?? 1);
                int pageSize = 6;
                if (productResult.Count == 0)
                {
                    ViewBag.Message = "Không tìm thấy!";
                }
                ViewBag.Product = productResult.OrderByDescending(x => x.Id).ToPagedList(pageNumber, pageSize);
            }


            else
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1
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
                                         CreatedDate = p.CreatedDate,
                                     }).ToList();

                // phân trang
                int pageNumber = (Page ?? 1);
                int pageSize = 6;
                if (productResult.Count == 0)
                {
                    ViewBag.Message = "Không tìm thấy!";
                }
                ViewBag.Product = productResult.OrderByDescending(x => x.Id).ToPagedList(pageNumber, pageSize);
            }
            return View();
        }
    }
}