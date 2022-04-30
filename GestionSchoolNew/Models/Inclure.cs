using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class Inclure
    {
        [Key]
        public int IdInclure { get; set; }
        public virtual Trimestre _Trimestre { get; set; }
        public virtual AnneeScolaire _AnneeScolaire { get; set; }
    }
}