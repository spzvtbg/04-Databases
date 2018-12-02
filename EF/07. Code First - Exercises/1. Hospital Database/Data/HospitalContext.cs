namespace P01_HospitalDatabase
{
    using Microsoft.EntityFrameworkCore;

    using P01_HospitalDatabase.Data.Context;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext() { }

        public HospitalContext(DbContextOptions options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ContextConfiguring.Connection(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ContextModeling.Patient(modelBuilder);

            ContextModeling.Visitation(modelBuilder);

            ContextModeling.Diagnose(modelBuilder);

            ContextModeling.Medicament(modelBuilder);

            ContextModeling.PatientMedicament(modelBuilder);
        }

    }
}
