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
    public class ObtenirsController : Controller
    {
        private GestionSchoolNewContext db = new GestionSchoolNewContext();

        // GET: Obtenirs
        public async Task<ActionResult> Index()
        {
            return View(await db.Obtenirs.ToListAsync());
        }

        // GET: Obtenirs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obtenir obtenir = await db.Obtenirs.FindAsync(id);
            if (obtenir == null)
            {
                return HttpNotFound();
            }
            return View(obtenir);
        }

        // GET: Obtenirs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Obtenirs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdObtenir,Note,_DateNote")] Obtenir obtenir)
        {
            if (ModelState.IsValid)
            {
                db.Obtenirs.Add(obtenir);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(obtenir);
        }

        // GET: Obtenirs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obtenir obtenir = await db.Obtenirs.FindAsync(id);
            if (obtenir == null)
            {
                return HttpNotFound();
            }
            return View(obtenir);
        }

        // POST: Obtenirs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdObtenir,Note,_DateNote")] Obtenir obtenir)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obtenir).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(obtenir);
        }

        // GET: Obtenirs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obtenir obtenir = await db.Obtenirs.FindAsync(id);
            if (obtenir == null)
            {
                return HttpNotFound();
            }
            return View(obtenir);
        }

        // POST: Obtenirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Obtenir obtenir = await db.Obtenirs.FindAsync(id);
            db.Obtenirs.Remove(obtenir);
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
