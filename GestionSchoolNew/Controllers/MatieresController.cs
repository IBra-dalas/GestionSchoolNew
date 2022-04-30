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
    public class MatieresController : Controller
    {
        private GestionSchoolNewContext db = new GestionSchoolNewContext();

        // GET: Matieres
        public async Task<ActionResult> Index()
        {
            return View(await db.Matieres.ToListAsync());
        }

        // GET: Matieres/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matiere matiere = await db.Matieres.FindAsync(id);
            if (matiere == null)
            {
                return HttpNotFound();
            }
            return View(matiere);
        }

        // GET: Matieres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Matieres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdMatiere,LibelleMatiere")] Matiere matiere)
        {
            if (ModelState.IsValid)
            {
                db.Matieres.Add(matiere);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(matiere);
        }

        // GET: Matieres/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matiere matiere = await db.Matieres.FindAsync(id);
            if (matiere == null)
            {
                return HttpNotFound();
            }
            return View(matiere);
        }

        // POST: Matieres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdMatiere,LibelleMatiere")] Matiere matiere)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matiere).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(matiere);
        }

        // GET: Matieres/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matiere matiere = await db.Matieres.FindAsync(id);
            if (matiere == null)
            {
                return HttpNotFound();
            }
            return View(matiere);
        }

        // POST: Matieres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Matiere matiere = await db.Matieres.FindAsync(id);
            db.Matieres.Remove(matiere);
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
