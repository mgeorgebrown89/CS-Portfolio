using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using final.Models;


namespace final.Controllers
{
    public class HomeController : Controller
    {
        private ArtistContext db = new ArtistContext();

        public ActionResult Index()
        {
            return View(db.Genres.ToList());
        }

        public JsonResult Genre(int id)
        {
            var works = db.Genres.Find(id)
                                 .Classifications
                                 .ToList()
                                 .OrderBy(t => t.Artwork.Title)
                                 .Select(a => new { aw = a.ArtworkID, awa = a.Artwork.ArtistID })
                                 .ToList();

            string[] artworkCreator = new string[works.Count()];
            for (int i = 0; i < artworkCreator.Length; ++i)
            {
                artworkCreator[i] = $"<ul>{db.Artworks.Find(works[i].aw).Title} by {db.Artists.Find(works[i].awa).Name}</ul>";
            }
            var data = new
            {
                arr = artworkCreator
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}