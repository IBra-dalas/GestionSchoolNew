using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class Inscription
    {
        [Key]
        public int IdInscription { get; set; }
        public bool EtatEleve { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-mm-dd}")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]

        [Display(Name = "Date Inscription")]
        public string Datestring { get; set; }
        /*[Display(Name = "Date Inscription")]
        public string DateInscription { get; set; }


        public Inscription()
        {
            DateInscription =null;
        }*/
        public virtual Tranche _Tranche { get; set; }
        public virtual Eleve _Eleve { get; set; }
        public virtual Classe _Classe { get; set; }
       
        public virtual AnneeScolaire _AnneeScolaire { get; set; }
        [Display(Name = "Payer en ")]
        //   [ForeignKey("_ModePayement")]
        public virtual ModePayement _ModePayement { get; set; }
    }
}