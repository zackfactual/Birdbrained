using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Birdbrained.Models;

namespace Birdbrained.Areas.UserArea.Controllers
{
    public class UserBirdsController : Controller
    {
		// access database via entity framework
		private BirdbrainedEntities db = new BirdbrainedEntities();

        // GET: UserArea/UserBirds
        public ActionResult Index()
        {
			// sort index alphabetically by English Name
			var birds = from s in db.Birds
						select s;
			birds = birds.OrderBy(s => s.EnglishName);
			return View(birds.ToList());
		}

        // GET: UserArea/UserBirds/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bird bird = db.Birds.Find(id);
            if (bird == null)
            {
                return HttpNotFound();
            }
            return View(bird);
        }

		// clean up after yourself
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
