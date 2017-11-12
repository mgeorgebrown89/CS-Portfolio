using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using homework6.Models;

namespace homework6.Controllers
{
    public class HomeController : Controller
    {
        private AdvWorksContext db = new AdvWorksContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        //GET: Home/Bikes/sytle
        public ActionResult Bikes(string style)
        {
            var Bikes = db.Products.Where(s => s.ProductSubcategory.ProductCategory.Name == "Bikes");
            //I can't initialize it any other way. I can't figure it out.

            switch (style)
            {
                case "mountain":
                    Bikes = db.Products.Where(s => s.ProductSubcategory.Name == "Mountain Bikes");
                    ViewBag.BikeType = "Mountain Bikes";
                    break;
                case "road":
                    Bikes = db.Products.Where(s => s.ProductSubcategory.Name == "Road Bikes");
                    ViewBag.BikeType = "Road Bikes";
                    break;
                case "touring":
                    Bikes = db.Products.Where(s => s.ProductSubcategory.Name == "Touring Bikes");
                    ViewBag.BikeType = "Touring Bikes";
                    break;
                default:
                    ViewBag.BikeType = "All Bikes";
                    break;
            }
            return View(Bikes);
        }

        //Get:Home/Components/type
        public ActionResult Components(string type)
        {
            var Components = db.Products.Where(s => s.ProductSubcategory.ProductCategory.Name == "Components");
            string Type = type;//It didn't work when I just used "type" straight across
            if (Type == "All")
            {
                ViewBag.ComponentType = "All Components";
                return View(Components);
            }
            else
            {
                ViewBag.ComponentType = Type;
                return View(db.Products.Where(s => s.ProductSubcategory.Name == Type));
            }
        }
        //Get:Home/Clothing/part
        public ActionResult Clothing(string part)
        {
            var Clothing = db.Products.Where(s => s.ProductSubcategory.ProductCategory.Name == "Clothing");
            string Part = part;//It didn't work when I just used "type" straight across
            if (Part == "All")
            {
                ViewBag.ClothingPart = "All Clothing";
                return View(Clothing);
            }
            else
            {
                ViewBag.ClothingPart = Part;
                return View(db.Products.Where(s => s.ProductSubcategory.Name == Part));
            }
        }
        //Get:Home/Accessories/type
        public ActionResult Accessories(string type)
        {
            var Accessories = db.Products.Where(s => s.ProductSubcategory.ProductCategory.Name == "Accessories");
            string Type = type;//It didn't work when I just used "type" straight across
            if (Type == "All")
            {
                ViewBag.AccessoriesType = "All Accessories";
                return View(Accessories);
            }
            else
            {
                ViewBag.AccessoriesType = Type;
                return View(db.Products.Where(s => s.ProductSubcategory.Name == Type));
            }
        }
    }
}
