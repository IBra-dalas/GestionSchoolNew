using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using GestionSchoolNew.Models;

namespace GestionSchoolNew.Controllers
{
    public class ElevesController : Controller
    {
        private GestionSchoolNewContext db = new GestionSchoolNewContext();

        // GET: Eleves
        public async Task<ActionResult> Index()
        {
            return View(await db.Eleves.ToListAsync());
        }

        // GET: Eleves/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = await db.Eleves.FindAsync(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            return View(eleve);
        }

        // GET: Eleves/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eleves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdEleve,NomEleve,PrenomEleve,SexeEleve,DateNaissance,LieuNaissance,NomParent,PrenomParent,ProfessionParent,ContactParent,EmailParent,AdresseParent")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                db.Eleves.Add(eleve);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(eleve);
        }

        // GET: Eleves/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = await db.Eleves.FindAsync(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            return View(eleve);
        }

        // POST: Eleves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdEleve,NomEleve,PrenomEleve,SexeEleve,DateNaissance,LieuNaissance,NomParent,PrenomParent,ProfessionParent,ContactParent,EmailParent,AdresseParent")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eleve).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(eleve);
        }

        // GET: Eleves/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = await db.Eleves.FindAsync(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            return View(eleve);
        }

        // POST: Eleves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Eleve eleve = await db.Eleves.FindAsync(id);
            db.Eleves.Remove(eleve);
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
