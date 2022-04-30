using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class Associer
    {

        [Key]
        public int IdAssocier { get; set; }
        public int Coef { get; set; }
        public virtual Classe _Classe { get; set; }
        public virtual Matiere _Matiere { get; set; }

    }
}