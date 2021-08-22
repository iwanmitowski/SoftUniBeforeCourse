using _01.HospitalDatabase.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.HospitalDatabase.Data
{
    class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Diagnose> Diagnoses{ get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> Prescriptions { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Hospital;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>()
                .HasKey(x => new { x.MedicamentId, x.PatientId });
        }

    }
}
