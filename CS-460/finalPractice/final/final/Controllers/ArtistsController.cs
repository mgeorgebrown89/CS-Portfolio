using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using final.Models;

namespace final.Controllers
{
    public class ArtistsController : Controller
    {
        private ArtistContext db = new ArtistContext();

        // GET: Artists
        public ActionResult Index()
        {
            return View(db.Artists.ToList());
        }

        //GET: Artworks
        public ActionResult Artworks()
        {
            return View(db.Artworks.ToList());
        }

        // GET: Classifications
        public ActionResult Classifications()
        {
            return View(db.Classifications.ToList());
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistID,Name,BirthDate,BirthCity")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        // GET: Artists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistID,Name,BirthDate,BirthCity")] Artist artist)
        {
            string[] dob = artist.BirthDate.Split('/');

            int birthYear = Int32.Parse(dob[2]);
            int birthMonth = Int32.Parse(dob[0]);
            int birthDay = Int32.Parse(dob[1]);

            int yyyy = DateTime.Now.Year;
            int mm = DateTime.Now.Month;// jan is month 0
            int dd = DateTime.Now.Day;

            if (birthYear > yyyy)
            {
                TempData["testmsg"] = "<script>alert('Are you from the future?');</script>";
                return RedirectToAction("Edit");
            }
            else if (birthYear == yyyy && birthMonth > mm)
            {
                TempData["testmsg"] = "<script>alert('Are you from the future?');</script>";
                return RedirectToAction("Edit");
            }
            else if (birthYear == yyyy && birthMonth == mm && birthDay > dd)
            {
                TempData["testmsg"] = "<script>alert('Wait a minute, you're not born yet.');</script>";
                return RedirectToAction("Edit");
            }

            if (artist.Name.Length > 50)
            {
                TempData["testmsg"] = "<script>alert('Name is too long.');</script>";
                return RedirectToAction("Edit");
            }

            if (ModelState.IsValid)
            {
                    db.Entry(artist).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
