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
    public class ProfesseursController : Controller
    {
        private GestionSchoolNewContext db = new GestionSchoolNewContext();

        // GET: Professeurs
        public async Task<ActionResult> Index()
        {
            return View(await db.Professeurs.ToListAsync());
        }

        // GET: Professeurs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professeur professeur = await db.Professeurs.FindAsync(id);
            if (professeur == null)
            {
                return HttpNotFound();
            }
            return View(professeur);
        }

        // GET: Professeurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professeurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdProf,NomProf,PrenomProf,StatusProf")] Professeur professeur)
        {
            if (ModelState.IsValid)
            {
                db.Professeurs.Add(professeur);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(professeur);
        }

        // GET: Professeurs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professeur professeur = await db.Professeurs.FindAsync(id);
            if (professeur == null)
            {
                return HttpNotFound();
            }
            return View(professeur);
        }

        // POST: Professeurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdProf,NomProf,PrenomProf,StatusProf")] Professeur professeur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professeur).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(professeur);
        }

        // GET: Professeurs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professeur professeur = await db.Professeurs.FindAsync(id);
            if (professeur == null)
            {
                return HttpNotFound();
            }
            return View(professeur);
        }

        // POST: Professeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Professeur professeur = await db.Professeurs.FindAsync(id);
            db.Professeurs.Remove(professeur);
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
