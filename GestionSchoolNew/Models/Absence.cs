using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class Absence
    {
        [Key]
        public int IdAbsence { get; set;}
        public string MotifAbsence { get; set; }
        public DateTime DateAbsence { get; set; }
        public virtual Inclure _Inclure { get; set; }
        public virtual Eleve _Eleve { get; set; }
        public virtual Matiere _Matiere { get; set; }
    }
}