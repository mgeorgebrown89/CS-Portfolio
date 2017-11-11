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

        //GET: Home/MountainBikes
        public ActionResult MountainBikes()
        {
            var mBikes = db.Products.Where(s => s.ProductSubcategory.Name == "Mountain Bikes");

            return View(mBikes);
        }
    }
}
