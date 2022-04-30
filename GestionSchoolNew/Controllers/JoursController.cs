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
    public class JoursController : Controller
    {
        private GestionSchoolNewContext db = new GestionSchoolNewContext();

        // GET: Jours
        public async Task<ActionResult> Index()
        {
            return View(await db.Jours.ToListAsync());
        }

        // GET: Jours/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jour jour = await db.Jours.FindAsync(id);
            if (jour == null)
            {
                return HttpNotFound();
            }
            return View(jour);
        }

        // GET: Jours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdJour,LibelleJour")] Jour jour)
        {
            if (ModelState.IsValid)
            {
                db.Jours.Add(jour);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(jour);
        }

        // GET: Jours/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jour jour = await db.Jours.FindAsync(id);
            if (jour == null)
            {
                return HttpNotFound();
            }
            return View(jour);
        }

        // POST: Jours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdJour,LibelleJour")] Jour jour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jour).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jour);
        }

        // GET: Jours/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jour jour = await db.Jours.FindAsync(id);
            if (jour == null)
            {
                return HttpNotFound();
            }
            return View(jour);
        }

        // POST: Jours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Jour jour = await db.Jours.FindAsync(id);
            db.Jours.Remove(jour);
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
