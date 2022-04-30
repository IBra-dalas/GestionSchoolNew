using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class Heure
    {
        [Key]
        public int IdHeure { get; set; }
        public string HeureDebut { get; set; }
        public string HeureFin { get; set; }



    }
}