using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework5.DAL;
using Homework5.Models;

namespace Homework5.Controllers
{
    public class DMVFormsController : Controller
    {
        private DMVFormContext db = new DMVFormContext();

        // GET: DMVForms
        public ActionResult Index()
        {

           Response.Write(db.DMVForms.ToString());
            return View(db.DMVForms.ToList());
        }


    }
}