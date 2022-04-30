using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class Evaluation
    {
        [Key]
        public int IdEvaluation { get; set; }
        public string LibelleEvaluation { get; set; }
    }
}