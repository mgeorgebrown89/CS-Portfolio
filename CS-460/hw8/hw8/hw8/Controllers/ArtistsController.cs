﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hw8.Models;

namespace hw8.Controllers
{
    public class ArtistsController : Controller
    {
        private ArtistContext db = new ArtistContext();

        // GET: Artists
        public ActionResult Index()
        {
            var artists = db.Artists.ToList();
            return View(artists);
        }

        // Get: Artworks
        public ActionResult Artworks()
        {
            var artworks = db.Artworks.ToList();
            return View(artworks);
        }

        // GET: Classifications
        public ActionResult Classifications()
        {
            var classifications = db.Classifications.ToList();
            return View(classifications);
        }

        // GET: Artists/Details/5
        public ActionResult Details(int id)
        {
            var artist = db.Artists.Find(id);
            return View(artist);
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                var newArtist = db.Artists.Create();

                newArtist.Name = collection["Name"];
                newArtist.BirthCity = collection["BirthCity"];
                newArtist.BirthDate = collection["BirthDate"];

                db.Artists.Add(newArtist);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Artists/Edit/5
        public ActionResult Edit(int id)
        {
            var artist = db.Artists.Find(id);
            return View(artist);
        }

        // POST: Artists/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var editArtist = db.Artists.Find(id);

                editArtist.Name = collection["Name"];
                editArtist.BirthCity = collection["BirthCity"];
                editArtist.BirthDate = collection["BirthDate"];

                if (collection["Name"].Length > 50) //attribute checking for Name length
                {
                    TempData["testmsg"] = "<script>alert('Name cannot be more than 50 characters!');</script>";
                    return RedirectToAction("Edit");
                }

                //attribute checking for date of birth
                string[] dob = editArtist.BirthDate.Split('/');

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

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(int id)
        {
            var artists = db.Artists.Where(a => a.ArtistID == id).FirstOrDefault();
            return View(artists);
        }

        // POST: Artists/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var artist = db.Artists.Find(id);
                db.Artists.Remove(artist);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}