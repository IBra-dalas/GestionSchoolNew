using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class Jour
    {
        [Key]
        public int IdJour { get; set; }
        public string LibelleJour { get; set; }
    }
}