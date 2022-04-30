using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class Obtenir
    {
        [Key]
        public int IdObtenir { get; set; }
        public double Note { get; set; }
        public DateTime _DateNote { get; set; }
        public virtual Eleve _Eleve { get; set; }
        public virtual Inclure _Inclure { get; set; }
        public virtual Associer _Associer { get; set; }
        public virtual Evaluation _Evaluation { get; set; }
    }
}