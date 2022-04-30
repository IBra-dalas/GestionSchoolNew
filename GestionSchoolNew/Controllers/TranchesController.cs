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
    public class TranchesController : Controller
    {
        private GestionSchoolNewContext db = new GestionSchoolNewContext();

        // GET: Tranches
        public async Task<ActionResult> Index()
        {
            return View(await db.Tranches.ToListAsync());
        }

        // GET: Tranches/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tranche tranche = await db.Tranches.FindAsync(id);
            if (tranche == null)
            {
                return HttpNotFound();
            }
            return View(tranche);
        }

        // GET: Tranches/Create
        public ActionResult Create()
        {
            //var ModePaiementQuery = from ModPay in db.ModePayements
            //                       orderby ModPay.LibelleModePayement, ModPay.IdModePayement
            //                       select new { ModPay.IdModePayement, ModPay.LibelleModePayement };

            //foreach (var item in ModePaiementQuery)
            //{
            //    ModePayList.Add(new ModePayement { IdModePayement = item.IdModePayement, LibelleModePayement = item.LibelleModePayement });
            //}
            List<ModePayement> ModePayList = db.ModePayements.ToList();
            SelectList ListPaiement = new SelectList(ModePayList,  "LibelleModePayement", "IdModePayement",1);
            ViewBag.ModePayList = ListPaiement;
            return View();
        }

        // POST: Tranches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTranche,LibelleTranche,DatePayement")] Tranche tranche)
        {
           


            if (ModelState.IsValid)
            {

               
                db.Tranches.Add(tranche);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tranche);
        }

        // GET: Tranches/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tranche tranche = await db.Tranches.FindAsync(id);
            if (tranche == null)
            {
                return HttpNotFound();
            }
            return View(tranche);
        }


        //Get selectList of Mode de paiement

        

        // POST: Tranches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTranche,LibelleTranche,DatePayement,IdModePayement")] Tranche tranche)
        {
            if (ModelState.IsValid)
            {
               
                db.Entry(tranche).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tranche);
        }

        // GET: Tranches/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tranche tranche = await db.Tranches.FindAsync(id);
            if (tranche == null)
            {
                return HttpNotFound();
            }
            return View(tranche);
        }

        // POST: Tranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tranche tranche = await db.Tranches.FindAsync(id);
            db.Tranches.Remove(tranche);
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
