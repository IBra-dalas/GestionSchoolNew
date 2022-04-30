using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GestionSchoolNew.Models
{
    public class GestionSchoolNewContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public GestionSchoolNewContext() : base("name=GestionSchoolNewContext")
        {
        }

        public System.Data.Entity.DbSet<GestionSchoolNew.Models.Eleve> Eleves { get; set; }

        public System.Data.Entity.DbSet<GestionSchoolNew.Models.ModePayement> ModePayements { get; set; }

        public System.Data.Entity.DbSet<GestionSchoolNew.Models.Tranche> Tranches { get; set; }

        public System.Data.Entity.DbSet<GestionSchoolNew.Models.Professeur> Professeurs { get; set; }

        public System.Data.Entity.DbSet<GestionSchoolNew.Models.Matiere> Matieres { get; set; }

        public System.Data.Entity.DbSet<GestionSchoolNew.Models.Enseigner> Enseigners { get; set; }

        public System.Data.Entity.DbSet<GestionSchoolNew.Models.Jour> Jours { get; set; }

        public System.Data.Entity.DbSet<GestionSchoolNew.Models.Heure> Heures { get; set; }

        public System.Data.Entity.DbSet<GestionSchoolNew.Models.Salle> Salles { get; set; }

        public System.Data.Entity.DbSet<GestionSchoolNew.Models.Evaluation> Evaluations { get; set; }

        public System.Data.Entity.DbSet<GestionSchoolNew.Models.Trimestre> Trimestres { get; set; }

        public System.Data.Entity.DbSet<GestionSchoolNew.Models.AnneeScolaire> AnneeScolaires { get; set; }

        public System.Data.Entity.DbSet<GestionSchoolNew.Models.Inclure> Inclures { get; set; }

        public System.Data.Entity.DbSet<GestionSchoolNew.Models.Absence> Absences { get; set; }

        public System.Data.Entity.DbSet<GestionSchoolNew.Models.Classe> Classes { get; set; }

        public System.Data.Entity.DbSet<GestionSchoolNew.Models.Inscription> Inscriptions { get; set; }

        public System.Data.Entity.DbSet<GestionSchoolNew.Models.Associer> Associers { get; set; }

        public DbSet<cours> cours { get; set; }

        public DbSet<Obtenir> Obtenirs { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Inscription>().Property(e => e.DateInscription).HasColumnType("datetime2");

        //    //modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
