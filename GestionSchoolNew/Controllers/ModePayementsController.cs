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
    public class ModePayementsController : Controller
    {
        private GestionSchoolNewContext db = new GestionSchoolNewContext();

        // GET: ModePayements
        public async Task<ActionResult> Index()
        {
            return View(await db.ModePayements.ToListAsync());
        }

        // GET: ModePayements/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModePayement modePayement = await db.ModePayements.FindAsync(id);
            if (modePayement == null)
            {
                return HttpNotFound();
            }
            return View(modePayement);
        }

        // GET: ModePayements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModePayements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdModePayement,LibelleModePayement")] ModePayement modePayement)
        {
            if (ModelState.IsValid)
            {
                db.ModePayements.Add(modePayement);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(modePayement);
        }

        // GET: ModePayements/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModePayement modePayement = await db.ModePayements.FindAsync(id);
            if (modePayement == null)
            {
                return HttpNotFound();
            }
            return View(modePayement);
        }

        // POST: ModePayements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdModePayement,LibelleModePayement")] ModePayement modePayement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modePayement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(modePayement);
        }

        // GET: ModePayements/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModePayement modePayement = await db.ModePayements.FindAsync(id);
            if (modePayement == null)
            {
                return HttpNotFound();
            }
            return View(modePayement);
        }

        // POST: ModePayements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ModePayement modePayement = await db.ModePayements.FindAsync(id);
            db.ModePayements.Remove(modePayement);
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
