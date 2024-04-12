using Final_Project_Api.Data.EntitiesConfiguration;
using Final_Project_Api.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<AppointmentMedicine> AppointmentMedicines { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public DbSet<AnalysisType> AnalysisTypes { get; set; }
        public DbSet<AppointmentAnalysis> AppointmentAnalyses { get; set; }
        public DbSet<AppointmentDiagnose> AppointmentDiagnoses { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<AppointmentTime> AppointmentTimes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
       


        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Booking>(new BookingConfiguration());
            modelBuilder.ApplyConfiguration<Appointment>(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration<AppointmentTime>(new AppointmentTimeConfiguration());
            modelBuilder.ApplyConfiguration<Specialization>(new SpecializationConfiguration());
           

            base.OnModelCreating(modelBuilder);
        }
    }
}