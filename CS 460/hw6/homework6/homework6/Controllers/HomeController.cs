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
        /// <summary>
        /// Loads the homepage.
        /// </summary>
        /// <returns>homepage view</returns>
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Provides the relevant details of the product.
        /// </summary>
        /// <param name="id">The specific ID of the product</param>
        /// <returns>the details of a specific product in a view. also displays photo</returns>
        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Product = db.Products.Find(id);

            byte[] image = Product.ProductProductPhotoes.FirstOrDefault().ProductPhoto.LargePhoto;
            ViewBag.image = "data:image/png;base64," + Convert.ToBase64String(image, 0, image.Length);

            if (Product == null)
            {
                return HttpNotFound();
            }
            return View(Product);
        }
        /// <summary>
        /// this is how the user reviews a specific product.
        /// </summary>
        /// <param name="id">productID of specific product</param>
        /// <returns>a review form</returns>
        // Get: Home/Review/5
        public ActionResult Review(int? id)
        { 
            var Product = db.Products.Find(id);
            ViewBag.product = Product.Name;
            ProductReview PR = new ProductReview();
            PR.ProductID = Product.ProductID;
            return View(PR);
        }
        /// <summary>
        /// posts a review to a prodcuts detail page
        /// </summary>
        /// <param name="review">a review for a product</param>
        /// <returns>either homepage or redirects to the details page of the reviewed product</returns>
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
        /// <summary>
        /// displays bikes
        /// </summary>
        /// <param name="id">type of bike</param>
        /// <returns>returns specific subcategory, or all, of bikes</returns>
        //GET: Home/Bikes/sytle
        public ActionResult Bikes(string id)
        {
            string Style = id;
            var Bikes = db.Products.Where(s => s.ProductSubcategory.ProductCategory.Name == "Bikes");

            if (Style == "All" || Style == null)
            {
                ViewBag.BikeType = "All Bikes";
                /*foreach (var bike in Bikes)
                {
                    byte[] image = bike.ProductProductPhotoes.FirstOrDefault().ProductPhoto.LargePhoto;
                    ViewBag.image = "data:image/png;base64," + Convert.ToBase64String(image, 0, image.Length);
                }*/
                return View(Bikes.ToList());
            }
            else
            {
                Bikes = db.Products.Where(s => s.ProductSubcategory.Name == Style + " Bikes");
                ViewBag.BikeType = Style + " Bikes";
                /*foreach (var bike in Bikes)
                {
                    byte[] image = bike.ProductProductPhotoes.FirstOrDefault().ProductPhoto.LargePhoto;
                    ViewBag.image = "data:image/png;base64," + Convert.ToBase64String(image, 0, image.Length);
                }*/
                return View(Bikes.ToList());

            }
            
            /*switch (id)
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
            return View(Bikes.ToList());*/
        }
        /// <summary>
        /// displays components
        /// </summary>
        /// <param name="id">type of component</param>
        /// <returns>returns view of subcategory of component</returns>
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
        /// <summary>
        /// displays clothing
        /// </summary>
        /// <param name="id">type of clothing</param>
        /// <returns>view of subcategory of clothing</returns>
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
        /// <summary>
        /// displays accessories
        /// </summary>
        /// <param name="id">type of accessory</param>
        /// <returns>view of subcateogry of accessory</returns>
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
