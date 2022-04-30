
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
    public class IncluresController : Controller
    {
        private GestionSchoolNewContext db = new GestionSchoolNewContext();

        // GET: Inclures
        public async Task<ActionResult> Index()
        {
            return View(await db.Inclures.ToListAsync());
        }

        // GET: Inclures/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inclure inclure = await db.Inclures.FindAsync(id);
            if (inclure == null)
            {
                return HttpNotFound();
            }
            return View(inclure);
        }

        // GET: Inclures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inclures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdInclure")] Inclure inclure)
        {
            if (ModelState.IsValid)
            {
                db.Inclures.Add(inclure);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(inclure);
        }

        // GET: Inclures/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inclure inclure = await db.Inclures.FindAsync(id);
            if (inclure == null)
            {
                return HttpNotFound();
            }
            return View(inclure);
        }

        // POST: Inclures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdInclure")] Inclure inclure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inclure).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(inclure);
        }

        // GET: Inclures/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inclure inclure = await db.Inclures.FindAsync(id);
            if (inclure == null)
            {
                return HttpNotFound();
            }
            return View(inclure);
        }

        // POST: Inclures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Inclure inclure = await db.Inclures.FindAsync(id);
            db.Inclures.Remove(inclure);
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
