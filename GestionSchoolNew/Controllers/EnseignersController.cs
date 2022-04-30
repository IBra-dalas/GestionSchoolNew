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
    public class EnseignersController : Controller
    {
        private GestionSchoolNewContext db = new GestionSchoolNewContext();

        // GET: Enseigners
        public async Task<ActionResult> Index()
        {
            return View(await db.Enseigners.ToListAsync());
        }

        // GET: Enseigners/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enseigner enseigner = await db.Enseigners.FindAsync(id);
            if (enseigner == null)
            {
                return HttpNotFound();
            }
            return View(enseigner);
        }

        // GET: Enseigners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enseigners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdEnseigner")] Enseigner enseigner)
        {
            if (ModelState.IsValid)
            {
                db.Enseigners.Add(enseigner);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(enseigner);
        }

        // GET: Enseigners/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enseigner enseigner = await db.Enseigners.FindAsync(id);
            if (enseigner == null)
            {
                return HttpNotFound();
            }
            return View(enseigner);
        }

        // POST: Enseigners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdEnseigner")] Enseigner enseigner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enseigner).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(enseigner);
        }

        // GET: Enseigners/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enseigner enseigner = await db.Enseigners.FindAsync(id);
            if (enseigner == null)
            {
                return HttpNotFound();
            }
            return View(enseigner);
        }

        // POST: Enseigners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Enseigner enseigner = await db.Enseigners.FindAsync(id);
            db.Enseigners.Remove(enseigner);
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
