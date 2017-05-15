using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        // GET: Store
        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
            return View(genres);
        }

        /*
         *  We’re using the HttpUtility.HtmlEncode utility method to sanitize the user input
         */
        //Get: /Store/Browse?genre=Disco
        public ActionResult Browse(string genre)
        {
            var genreModel = storeDB.Genres.Include("Albums")
                .Single(g=>g.Name==genre);
            return View(genreModel);
        }

        //Get /Store/details/5
        public ActionResult Details(int id)
        { 
            var album = storeDB.Albums.Find(id);
            return View(album);
        }
     }
}
 