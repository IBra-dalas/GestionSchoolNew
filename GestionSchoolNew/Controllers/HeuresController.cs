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
    public class HeuresController : Controller
    {
        private GestionSchoolNewContext db = new GestionSchoolNewContext();

        // GET: Heures
        public async Task<ActionResult> Index()
        {
            return View(await db.Heures.ToListAsync());
        }

        // GET: Heures/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heure heure = await db.Heures.FindAsync(id);
            if (heure == null)
            {
                return HttpNotFound();
            }
            return View(heure);
        }

        // GET: Heures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Heures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdHeure,HeureDebut,HeureFin")] Heure heure)
        {
            if (ModelState.IsValid)
            {
                db.Heures.Add(heure);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(heure);
        }

        // GET: Heures/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heure heure = await db.Heures.FindAsync(id);
            if (heure == null)
            {
                return HttpNotFound();
            }
            return View(heure);
        }

        // POST: Heures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdHeure,HeureDebut,HeureFin")] Heure heure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heure).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(heure);
        }

        // GET: Heures/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heure heure = await db.Heures.FindAsync(id);
            if (heure == null)
            {
                return HttpNotFound();
            }
            return View(heure);
        }

        // POST: Heures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Heure heure = await db.Heures.FindAsync(id);
            db.Heures.Remove(heure);
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
