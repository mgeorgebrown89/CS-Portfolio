using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hw5b.DAL;
using hw5b.Models;

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

        // Get: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, ODL, DOB, Name, StreetAddress, City, State, Zip, Country")] DMVForm form)
        {
            if (ModelState.IsValid)
            {
                db.DMVForms.Add(form);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(form);
        }
    }
}