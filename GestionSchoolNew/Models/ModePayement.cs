using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class ModePayement
    {
        [Key]
        public int IdModePayement { get; set; }
        [Display(Name ="Payer en")]
        public string LibelleModePayement { get; set; }

    }
}