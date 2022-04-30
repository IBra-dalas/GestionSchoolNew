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
    public class AnneeScolairesController : Controller
    {
        private GestionSchoolNewContext db = new GestionSchoolNewContext();

        // GET: AnneeScolaires
        public async Task<ActionResult> Index()
        {
            return View(await db.AnneeScolaires.ToListAsync());
        }

        // GET: AnneeScolaires/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnneeScolaire anneeScolaire = await db.AnneeScolaires.FindAsync(id);
            if (anneeScolaire == null)
            {
                return HttpNotFound();
            }
            return View(anneeScolaire);
        }

        // GET: AnneeScolaires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnneeScolaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdAnneeScolaire,LibelleAnneeScolaire")] AnneeScolaire anneeScolaire)
        {
            if (ModelState.IsValid)
            {
                db.AnneeScolaires.Add(anneeScolaire);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(anneeScolaire);
        }

        // GET: AnneeScolaires/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnneeScolaire anneeScolaire = await db.AnneeScolaires.FindAsync(id);
            if (anneeScolaire == null)
            {
                return HttpNotFound();
            }
            return View(anneeScolaire);
        }

        // POST: AnneeScolaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdAnneeScolaire,LibelleAnneeScolaire")] AnneeScolaire anneeScolaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anneeScolaire).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(anneeScolaire);
        }

        // GET: AnneeScolaires/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnneeScolaire anneeScolaire = await db.AnneeScolaires.FindAsync(id);
            if (anneeScolaire == null)
            {
                return HttpNotFound();
            }
            return View(anneeScolaire);
        }

        // POST: AnneeScolaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AnneeScolaire anneeScolaire = await db.AnneeScolaires.FindAsync(id);
            db.AnneeScolaires.Remove(anneeScolaire);
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
