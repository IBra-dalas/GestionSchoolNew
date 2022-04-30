using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class Eleve
    {
        [Key]
        public int IdEleve { get; set; }
        public string NomEleve { get; set; }
        public string PrenomEleve { get; set; }
        public string SexeEleve { get; set; }
        public DateTime DateNaissance { get; set; }
        public string LieuNaissance { get; set; }
        public string NomParent { get; set; }
        public string PrenomParent { get; set; }
        public string ProfessionParent { get; set; }
        public int ContactParent { get; set; }
        public string EmailParent { get; set; }
        public string AdresseParent { get; set; }
    }
}