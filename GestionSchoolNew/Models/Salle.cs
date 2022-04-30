using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class Salle
    {
        [Key]
        public int IdSalle { get; set; }
        public string LibelleSalle { get; set; }
    }
}