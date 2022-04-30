using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class cours
    {
        [Key]
        public int IdCours { get; set; }
        public virtual Enseigner _Enseigner { get; set; }
        public virtual Jour _Jour { get; set; }
        public virtual Heure _Heure { get; set; }
        public virtual Salle _Salle { get; set; }
        public virtual AnneeScolaire _AnneeScolaire { get; set; }
        public virtual Classe _Classe { get; set; }
    }
}