using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class Tranche
    {
       //private GestionSchoolNewContext db = new GestionSchoolNewContext();

        [Key]
        public int IdTranche { get; set; }
        [Display(Name = "Tranche")]
        public string LibelleTranche { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        [Display(Name ="Date de Paiement")]
        public DateTime DatePayement { get; set; }
        
        //public ModePayement GetModePaiement(int id)
        //{
        //    ModePayement modePayement = db.ModePayements.Where(a => a.IdModePayement == id).FirstOrDefault();
        //    return modePayement;
        //}
        //public IEnumerable<ModePayement> AutreModePaiement = new List<ModePayement>
        //{
        //        new ModePayement {LibelleModePayement = "CB"},
        //        new ModePayement{LibelleModePayement = "Espéce"}
        //};
    }
}