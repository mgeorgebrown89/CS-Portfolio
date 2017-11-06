using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hw5b.DAL;

namespace hw5b.Controllers
{
    public class DMVFormsController : Controller
    {
        private DMVFormContext db = new DMVFormContext();
        // GET: Forms
        public ActionResult Index()
        {
            return View(db.DMVForms.ToList());
        }
    }
}