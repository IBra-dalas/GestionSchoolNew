using System.ComponentModel.DataAnnotations;

namespace GestionSchoolNew.Models
{
    public class Enseigner
    {
        [Key]
        public int IdEnseigner { get; set; }
        public virtual Matiere _Matiere { get; set; }
        public virtual Professeur _Professeur { get; set; }

    }
}