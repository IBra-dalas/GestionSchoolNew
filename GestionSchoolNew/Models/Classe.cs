using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class Classe
    {
        [Key]
        public int IdClasse { get; set; }
        public string LibelleClasse { get; set; }

    }
}