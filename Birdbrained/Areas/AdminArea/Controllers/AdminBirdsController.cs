using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Birdbrained.Models;

namespace Birdbrained.Areas.AdminArea.Controllers
{
	// ensure that only admin can access administrative views and functions
	[Authorize(Roles = "Admin")] 
	public class AdminBirdsController : Controller
    {
		// access database via entity framework
        private BirdbrainedEntities db = new BirdbrainedEntities();

        // GET: AdminArea/AdminBirds
        public ActionResult Index()
        {
			// sort index alphabetically by English Name
			var birds = from s in db.Birds
						select s;
			birds = birds.OrderBy(s => s.EnglishName);
			return View(birds.ToList());
		}

        // GET: AdminArea/AdminBirds/Details/5
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

        // GET: AdminArea/AdminBirds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminArea/AdminBirds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EnglishName,Class,Order,Family,Subfamily,Genus,Species,LearnMoreHyperlink,Photo")] Bird bird)
        {
            if (ModelState.IsValid)
            {
                bird.Id = Guid.NewGuid();
                db.Birds.Add(bird);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bird);
        }

        // GET: AdminArea/AdminBirds/Edit/5
        public ActionResult Edit(Guid? id)
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

        // POST: AdminArea/AdminBirds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EnglishName,Class,Order,Family,Subfamily,Genus,Species,LearnMoreHyperlink,Photo")] Bird bird)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bird).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bird);
        }

        // GET: AdminArea/AdminBirds/Delete/5
        public ActionResult Delete(Guid? id)
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

        // POST: AdminArea/AdminBirds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Bird bird = db.Birds.Find(id);
            db.Birds.Remove(bird);
            db.SaveChanges();
            return RedirectToAction("Index");
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
