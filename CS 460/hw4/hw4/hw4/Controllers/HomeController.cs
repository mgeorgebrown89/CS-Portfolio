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
            ViewBag.Message = "Page 1: Temperature Converter";
            ViewBag.RequestMethod = "GET";
            int temp = Convert.ToInt32(Request.QueryString["temp"]);
            
            int convTemp = 0;
            string inputDeg = "";
            string deg = "";

            if (Request.QueryString["radio"] == "c")
            {
                inputDeg = "C";
            }
            else if (Request.QueryString["radio"] == "f")
            {
                inputDeg = "F";
            }
            else
            {
                Response.Write("Please select a degree type.");
            }


            if (inputDeg == "C")
            {
                convTemp = temp * (9 / 5) + 32;
                deg = "F";
            }
            else if (inputDeg == "F")
            {
                convTemp = (temp - 32) / (9/5);
                deg = "C";
            }
            else
            {
                Response.Write("Can't divide by zero!");
            }

            Response.Write(temp + " degrees " + inputDeg + " is " + convTemp + " degrees " + deg);
            
            return View();
        }

     /*   // POST: Home/Page1
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
        } */
    }
}