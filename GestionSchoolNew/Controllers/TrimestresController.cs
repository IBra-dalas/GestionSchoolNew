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
    public class TrimestresController : Controller
    {
        private GestionSchoolNewContext db = new GestionSchoolNewContext();

        // GET: Trimestres
        public async Task<ActionResult> Index()
        {
            return View(await db.Trimestres.ToListAsync());
        }

        // GET: Trimestres/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trimestre trimestre = await db.Trimestres.FindAsync(id);
            if (trimestre == null)
            {
                return HttpNotFound();
            }
            return View(trimestre);
        }

        // GET: Trimestres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trimestres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTrimestre,LibelleTrimestre,DebutTrimestre,FinTrimestre")] Trimestre trimestre)
        {
            if (ModelState.IsValid)
            {
                db.Trimestres.Add(trimestre);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(trimestre);
        }

        // GET: Trimestres/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trimestre trimestre = await db.Trimestres.FindAsync(id);
            if (trimestre == null)
            {
                return HttpNotFound();
            }
            return View(trimestre);
        }

        // POST: Trimestres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTrimestre,LibelleTrimestre,DebutTrimestre,FinTrimestre")] Trimestre trimestre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trimestre).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(trimestre);
        }

        // GET: Trimestres/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trimestre trimestre = await db.Trimestres.FindAsync(id);
            if (trimestre == null)
            {
                return HttpNotFound();
            }
            return View(trimestre);
        }

        // POST: Trimestres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Trimestre trimestre = await db.Trimestres.FindAsync(id);
            db.Trimestres.Remove(trimestre);
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
