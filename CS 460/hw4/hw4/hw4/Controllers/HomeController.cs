using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace hw4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = "This the Home Page.";
            return View();
        }

        // GET: Home/Page1
        [HttpGet]
        public ActionResult Page1()
        {
            ViewBag.RequestMethod = "GET";
            return View();
        }

        // POST: Home/Page1
        [HttpPost]
        public ActionResult Page1(string name, string password, int? age)
        {
            ViewBag.Message = "This is Page1.";
            ViewBag.RequestMethod = "POST";
            // What to do if we don't get something we need?  For now let's just
            // tell the client they're "Bad" :-)
            if (age == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Looks good, we can use this data
            Debug.WriteLine($"{name}:{password}:{age}");

            // And then redirect the user to another page (if desired)
            //return RedirectToAction("Index");

            // or return the same page
            return View();
        }
    }
}