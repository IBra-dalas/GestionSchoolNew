using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class Trimestre
    {
        [Key]
        public int IdTrimestre { get; set; }
        public string LibelleTrimestre { get; set; }
        public DateTime DebutTrimestre { get; set; }
        public DateTime FinTrimestre { get; set; }

    }
}