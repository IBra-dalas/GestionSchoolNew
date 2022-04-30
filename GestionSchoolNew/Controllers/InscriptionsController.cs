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
using System.Data.SqlTypes;

namespace GestionSchoolNew
{
    public class InscriptionsController : Controller
    {
        private GestionSchoolNewContext db = new GestionSchoolNewContext();

        // GET: Inscriptions
        public async Task<ActionResult> Index()
        {
            return View(await db.Inscriptions.ToListAsync());
        }

        // GET: Inscriptions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscription inscription = await db.Inscriptions.FindAsync(id);
            if (inscription == null)
            {
                return HttpNotFound();
            }
            return View(inscription);
        }

        // GET: Inscriptions/Create
        public ActionResult Create()
        {
            //Liste des Tranche

            List<Tranche> ListTranche = db.Tranches.ToList();
            SelectList selectListTrance = new SelectList(ListTranche, "IdTranche", "LibelleTranche", 1);
            //ViewBag.ListTranche = selectListTrance;

            ViewBag.DropDownValue = selectListTrance;

            //Mode de paiement

            List<ModePayement> ListModePayement = db.ModePayements.ToList();
            SelectList selectListsModePayement = new SelectList(ListModePayement, "IdModePayement", "LibelleModePayement", 1);
            ViewBag.DropMaValeur = selectListsModePayement;

            //Liste des Eleves

            List<Eleve> ListEleve = db.Eleves.ToList();
            SelectList selectListEleve = new SelectList(ListEleve, "IdEleve", "NomEleve", 1);
            ViewBag.ListEleve = selectListEleve;

            //Liste des Classes

            List<Classe> ListClasse = db.Classes.ToList();
            SelectList selectListClasse = new SelectList(ListClasse, "IdClasse", "LibelleClasse", 1);
            ViewBag.ListClasse = selectListClasse;

            //Liste Année scolaire

            List<AnneeScolaire> ListAnneeSclaire = db.AnneeScolaires.ToList();
            SelectList selectListAnnScolaire = new SelectList(ListAnneeSclaire, "IdAnneeScolaire", "LibelleAnneeScolaire", 1);
            ViewBag.ListAnneeSclaire = selectListAnnScolaire;

            return View();
        }

        // POST: Inscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdInscription,EtatEleve,_AnneeScolaire,_Tranche,_Eleve,_ModePayement,_Classe")] Inscription inscription)
        {
            if (ModelState.IsValid)
            {

                var value = DateTime.Now;
                    
                       
                            var date = (DateTime)value;
                           /* if (date < SqlDateTime.MinValue.Value)
                            {*/
                              inscription.Datestring = date.ToString();
                          /*  }*/
                            /*else if (date > SqlDateTime.MaxValue.Value)
                            {
                                 inscription.DateInscription = SqlDateTime.MaxValue.Value;
                            }
                       */
                    
                
               // inscription.DateInscription = DateTime.Now.Date;
                db.Inscriptions.Add(inscription);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(inscription);
        }

        // GET: Inscriptions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscription inscription = await db.Inscriptions.FindAsync(id);
            if (inscription == null)
            {
                return HttpNotFound();
            }
            return View(inscription);
        }

        // POST: Inscriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdInscription,EtatEleve")] Inscription inscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscription).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(inscription);
        }

        // GET: Inscriptions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscription inscription = await db.Inscriptions.FindAsync(id);
            if (inscription == null)
            {
                return HttpNotFound();
            }
            return View(inscription);
        }

        // POST: Inscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Inscription inscription = await db.Inscriptions.FindAsync(id);
            db.Inscriptions.Remove(inscription);
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
