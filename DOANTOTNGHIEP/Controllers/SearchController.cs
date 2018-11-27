using DOANTOTNGHIEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace DOANTOTNGHIEP.Controllers
{
    public class SearchController : Controller
    {
        NhaTroEntities db = new NhaTroEntities();
        // GET: Search
        [HttpPost]
        public ActionResult Search(FormCollection f)
        {
            string location = f["location"].ToString();
            string prv = f["province"].ToString();
            int province = Convert.ToInt32(prv);
            string dst = f["district"].ToString();
            int district = Convert.ToInt32(dst);
            string sdt = f["dientich"].ToString();
            int dientich = Convert.ToInt32(sdt);
            string pr = f["price"].ToString();
            double price = Convert.ToDouble(pr);

            if (dientich == 1 && location == "" && price == 1)
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
                                     }).OrderBy(x => x.Id);

                ViewBag.Product = productResult;
            }

            else if (dientich == 1 && location == null && price == 2)
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1 && pv.Id == province && dt.Id == district && p.Acreage <= 20 &&  p.Price <= 5000000 && p.Price >= 2000000
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
                                     }).OrderBy(x => x.Id);

                ViewBag.Product = productResult;
            }

            else if (dientich == 1 && location == null && price == 3)
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
                                     }).OrderBy(x => x.Id);

                ViewBag.Product = productResult;
            }

            else if (dientich == 2 && location == null && price == 1)
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1 && l.Name == location && pv.Id == province && dt.Id == district && 20 <= p.Acreage && p.Acreage <= 20 && p.Price < 2000000
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
                                     }).OrderBy(x => x.Id);

                ViewBag.Product = productResult;
            }

            else if (dientich == 2 && location == null && price == 2)
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1 && l.Name == location && pv.Id == province && dt.Id == district && 20 <= p.Acreage && p.Acreage <= 20 && p.Price <= 5000000 && p.Price >= 2000000
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
                                     }).OrderBy(x => x.Id);

                ViewBag.Product = productResult;
            }

            else if (dientich == 2 && location == null && price == 3)
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1 && l.Name == location && pv.Id == province && dt.Id == district && 20 <= p.Acreage && p.Acreage <= 20 && p.Price > 5000000
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
                                     }).OrderBy(x => x.Id);

                ViewBag.Product = productResult;
            }

            else if (dientich == 3 && location == null && price == 1)
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1 && l.Name == location && pv.Id == province && dt.Id == district && 30 <= p.Acreage && p.Price < 2000000
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
                                     }).OrderBy(x => x.Id);

                ViewBag.Product = productResult;
            }

            else if (dientich == 3 && location == null && price == 2)
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1 && l.Name == location && pv.Id == province && dt.Id == district && 30 <= p.Acreage && p.Price <= 5000000 && p.Price >= 2000000
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
                                     }).OrderBy(x => x.Id);

                ViewBag.Product = productResult;
            }

            else if (dientich == 3 && location == null && price == 3)
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1 && l.Name == location && pv.Id == province && dt.Id == district && 30 <= p.Acreage && p.Price > 5000000
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
                                     }).OrderBy(x => x.Id);

                ViewBag.Product = productResult;
            }


            else
            {
                var productResult = (from p in db.Product
                                     join pt in db.ProductType on p.IdProductType equals pt.Id
                                     join s in db.Street on p.IdStreet equals s.Id
                                     join dt in db.District on s.IdDistrict equals dt.Id
                                     join l in db.Location on p.IdLocation equals l.Id
                                     join pv in db.Province on dt.IdProvince equals pv.Id
                                     where p.IsActive == 1 && l.Name == location
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
                                     }).OrderBy(x => x.Id);
                ViewBag.Product = productResult;
            }

            return View();
        }


    }
}