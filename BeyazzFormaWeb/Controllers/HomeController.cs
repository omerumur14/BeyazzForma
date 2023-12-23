using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeyazzFormaWeb.Entity;
using BeyazzFormaWeb.Models;

namespace BeyazzFormaWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private DataContext _context = new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            var urunler = _context.Products.Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Price = i.Price,
                Image = i.Image ?? "f1.jpeg",
                CategoryId = i.CategoryId,
            });

            return View(urunler);
        }
        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(i => i.Id==id).FirstOrDefault());
        }
        public ActionResult List(int? id)
        {
            var urunler = _context.Products.Select(i => new ProductModel()
            {
                Id = i.Id,
                Name= i.Name.Length > 50 ? i.Name.Substring(0,47) + "..." : i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Price = i.Price,
                Image = i.Image ?? "f1.jpeg",
                CategoryId = i.CategoryId,
            }).AsQueryable();

            if (id != null)
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }

            return View(urunler.ToList());
        }

        public PartialViewResult GetCatogeries()
        {
            return PartialView(_context.Categories.ToList());
        }
    }
}