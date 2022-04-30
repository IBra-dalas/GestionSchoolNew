using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionSchoolNew.Models;

namespace GestionSchoolNew.Controllers
{
    public class AssociersController : Controller
    {
        private GestionSchoolNewContext db = new GestionSchoolNewContext();

        // GET: Associers
        public async Task<ActionResult> Index()
        {
            return View(await db.Associers.ToListAsync());
        }

        // GET: Associers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Associer associer = await db.Associers.FindAsync(id);
            if (associer == null)
            {
                return HttpNotFound();
            }
            return View(associer);
        }

        // GET: Associers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Associers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdAssocier,Coef")] Associer associer)
        {
            if (ModelState.IsValid)
            {
                db.Associers.Add(associer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(associer);
        }

        // GET: Associers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Associer associer = await db.Associers.FindAsync(id);
            if (associer == null)
            {
                return HttpNotFound();
            }
            return View(associer);
        }

        // POST: Associers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdAssocier,Coef")] Associer associer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(associer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(associer);
        }

        // GET: Associers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Associer associer = await db.Associers.FindAsync(id);
            if (associer == null)
            {
                return HttpNotFound();
            }
            return View(associer);
        }

        // POST: Associers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Associer associer = await db.Associers.FindAsync(id);
            db.Associers.Remove(associer);
            await db.SaveChangesAsync();
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
