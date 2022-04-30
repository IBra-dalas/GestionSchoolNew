using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class Professeur
    {
        [Key]
        public int IdProf { get; set; }
        public string NomProf { get; set; }
        public string PrenomProf { get; set; }
        public string StatusProf { get; set; }
        private int ContactProf { get; set; }
            
    }
}