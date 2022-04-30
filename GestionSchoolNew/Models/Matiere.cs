using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class Matiere
    {
        [Key]
        public int IdMatiere { get; set; }
        public string LibelleMatiere { get; set; }
    }
}