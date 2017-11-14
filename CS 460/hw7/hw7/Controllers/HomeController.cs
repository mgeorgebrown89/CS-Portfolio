using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hw7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        // GET: Home/RandomNumbers/10
        public JsonResult RandomNumbers(int? id = 100)
        {
            Random gen = new Random();
            int[] arr = new int[(int)id];       // yes, no checking at the moment
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = gen.Next(1000);
            }

            var data = new
            {
                message = "Hello from SimpleAPI",
                num = (int)id,
                numbers = arr
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}