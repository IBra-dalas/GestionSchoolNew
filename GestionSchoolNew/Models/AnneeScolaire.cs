using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class AnneeScolaire
    {
        [Key]
        public int IdAnneeScolaire { get; set; }
        public string LibelleAnneeScolaire { get; set; }

    }
}