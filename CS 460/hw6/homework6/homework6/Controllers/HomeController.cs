using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using homework6.Models;
using System.Diagnostics;

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
            var Product = db.Products.Find(id);
           // var Photo = db.ProductPhotoes.Find(id);
                
            if (Product == null)
            {
                return HttpNotFound();
            }
          //  ViewBag.Photo = Photo;
            return View(Product);
        }

        // Get: Home/Review/5
        public ActionResult Review(int? id)
        { 
            var Product = db.Products.Find(id);
            ViewBag.product = Product.Name;
            ProductReview PR = new ProductReview();
            PR.ProductID = Product.ProductID;
            return View(PR);
        }

        // Post: Home/Review/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Review([Bind(Include = "ProductReviewID, ProductID, ReviewerName, " +
            "ReviewDate, EmailAddress, Rating, Comments, CommentsModifiedDate, Product ")] ProductReview review)
        {
            string id = review.ProductID.ToString();
            ViewBag.ProductID = id;
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                review.ProductID = Convert.ToInt32(id);
                review.ReviewDate = DateTime.Now;
                review.ModifiedDate = review.ReviewDate;
                review.Product = db.Products.Where(p => p.ProductID.ToString() == id).FirstOrDefault();

                db.ProductReviews.Add(review);
                db.SaveChanges();

                return Redirect("/Home/Details/" + id);
            }

            return View(review);
        }

        //GET: Home/Bikes/sytle
        public ActionResult Bikes(string id)
        {
            var Bikes = db.Products.Where(s => s.ProductSubcategory.ProductCategory.Name == "Bikes");
            //ViewBag.BikesPhoto = (db.ProductPhotoes.Where(p => p.ProductPhotoID == 69).Select(p => p.ThumbnailPhotoFileName)).ToString();
            //I can't initialize it any other way. I can't figure it out.

            switch (id)
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
            return View(Bikes.ToList());
        }

        //Get:Home/Components/type
        public ActionResult Components(string id)
        {
            var Components = db.Products.Where(s => s.ProductSubcategory.ProductCategory.Name == "Components");
            string Type = id;//It didn't work when I just used "type" straight across
            if (Type == "All")
            {
                ViewBag.ComponentType = "All Components";
                return View(Components.ToList());
            }
            else
            {
                Components = db.Products.Where(s => s.ProductSubcategory.Name == Type);
                ViewBag.ComponentType = Type;
                return View(Components.ToList());
            }
        }
        //Get:Home/Clothing/part
        public ActionResult Clothing(string id)
        {
            var Clothing = db.Products.Where(s => s.ProductSubcategory.ProductCategory.Name == "Clothing");
            string Part = id;//It didn't work when I just used "type" straight across
            if (Part == "All")
            {
                ViewBag.ClothingPart = "All Clothing";
                return View(Clothing);
            }
            else
            {
                Clothing = db.Products.Where(s => s.ProductSubcategory.Name == Part);
                ViewBag.ClothingPart = Part;
                return View(Clothing.ToList());
            }
        }
        //Get:Home/Accessories/type
        public ActionResult Accessories(string id)
        {
            var Accessories = db.Products.Where(s => s.ProductSubcategory.ProductCategory.Name == "Accessories");
            string Type = id;//It didn't work when I just used "type" straight across
            if (Type == "All")
            {
                ViewBag.AccessoriesType = "All Accessories";
                return View(Accessories);
            }
            else
            {
                Accessories = db.Products.Where(s => s.ProductSubcategory.Name == Type);
                ViewBag.AccessoriesType = Type;
                return View(Accessories.ToList());
            }
        }
    }
}
