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
            ViewBag.Message = "Homework 4's Home Page.";
            return View();
        }
        
        // GET: Home/Page1
        /// <summary>
        /// This page takes info from the user from a form
        /// and converts it into celsius or fahrenheit from the other. Uses Response.Write
        /// </summary>
        /// <returns>A page with results from temp coversion in a string.</returns>
        [HttpGet]
        public ActionResult Page1()
        {
            ViewBag.Message = "Page 1: Temperature Converter";

            double temp = Convert.ToInt32(Request.QueryString["temp"]);
            string degreeType = Request.QueryString["optradio"];
            double convTemp = 0;
            string convDeg = "";

            if (degreeType == "C")
            {
                convDeg = "F"; // what degree type we're converting INTO. 
                convTemp = (temp * (9 / 5)) + 32;
            }
            else
            {
                convDeg = "C"; // ^^^ CCCCC
                convTemp = (temp - 32) / (9 / 5);
            }

            Response.Write(temp + " degrees " + degreeType + " is " + convTemp + " degrees " + convDeg + ".");

            return View();
        }

        // GET: Home/Page2
        /// <summary>
        /// This is a slightly better page than the previous. 
        /// </summary>
        /// <returns>A view with an empty form</returns>
        [HttpGet]
        public ActionResult Page2()
        {
            ViewBag.Message = "Page 2: Temperature Converter 2.0";
            return View();
        }

        // POST: Home/Page2
        /// <summary>
        /// This returns a view with the converted temperature.
        /// </summary>
        /// <param name="form">The form with temperature info. Degrees and C or F.</param>
        /// <returns>Returns converted temp in a view</returns>
        [HttpPost]
        public ActionResult Page2(FormCollection form)
        {
            ViewBag.Message = "Page 2: Temperature Converter 2.0";
            //If user submits no data, do this:
            if (form == null)
            {
                Response.Write("Please enter something.");
            }

            double inputTemp = Convert.ToDouble(form["temp"]);
            double outputTemp = 0;
            string inputDeg = form["optradio"];
            string outputDeg = "";
            string result1, result2 = "";

            if (inputDeg == "C") //celsius to fahrenheit
            {
                outputDeg = "F";
                outputTemp = (inputTemp * (9 / 5)) + 32;
            }
            else if (inputDeg == "F") // fahrenheit to celsius
            {
                outputDeg = "C";
                outputTemp = (inputTemp - 32) / (9 / 5);
            }
            else
            {
                Response.Write("Please enter a value.");
            }

            result1 = inputTemp.ToString() + " " + inputDeg;
            result2 = outputTemp + " " + outputDeg;

            ViewBag.result1 = result1;
            ViewBag.result2 = result2;
            ViewBag.eq = " = ";


            return View();
        }

        //Get: Home/Page3
        /// <summary>
        /// This view is of a Monthly loan calculator.
        /// </summary>
        /// <returns>It returns a view with a form.</returns>
        [HttpGet]
        public ActionResult Page3() 
        {
            ViewBag.Mesage = "Page 3: Loan Calculator";
            return View();
        }

        //POST: Home/Page3
        /// <summary>
        /// This viwq takes info from the form and 
        /// calculates the monthly payments for a loan.
        /// </summary>
        /// <param name="principle">The initial amount of the loan.</param>
        /// <param name="rate">The annual interest rate.</param>
        /// <param name="term">How long, in months, the loan lasts</param>
        /// <returns>returns a view with monthly loan payment amount</returns>
        [HttpPost]
        public ActionResult Page3(double? principle, double? rate, double? term)
        {
            ViewBag.Message = "Monthly Loan Terms:";
            double prin = principle.Value; //initial amount
            double ra = rate.Value; // annual interest rate
            double ter = term.Value; // how long the loan is for in months

            double ratePerPeriod = (ra/100)/12; // rate per period

            double loanPayment = prin * (ratePerPeriod / (1 - Math.Pow((1 + ratePerPeriod), -ter)));


            ViewBag.principle = prin;
            ViewBag.rate = ra;
            ViewBag.term = ter;
            ViewBag.loan = Math.Round(loanPayment, 2);
           
            if (principle == null)
            {
                ViewBag.Answer = false;
            }
            else
            {
                ViewBag.Answer = true;
            }



            return View();
        }
    }
}