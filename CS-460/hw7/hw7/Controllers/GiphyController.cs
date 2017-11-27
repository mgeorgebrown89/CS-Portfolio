using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace hw7.Controllers
{
    public class GiphyController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public JsonResult Search(int? page=1)
        {
            string GiphyAPIKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];//get api key from outside repo
            string q = Request.QueryString["q"];//user's search
            string limit = Request.QueryString["limit"];//how many gifs to display

            //Giphy API
            string url = "https://api.giphy.com/v1/gifs/search?api_key=" + GiphyAPIKey + "&q=" + q + "&limit=" + limit + "&rating=g";

            WebRequest request = WebRequest.Create(url); //send request

            WebResponse response = request.GetResponse(); //get response
            Stream dataStream = response.GetResponseStream(); //start data stream
            string reader = new StreamReader(dataStream).ReadToEnd(); //read as a string

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer(); 
            var data = serializer.DeserializeObject(reader); //parse string into JSON object
            
            dataStream.Close();
            response.Close();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}