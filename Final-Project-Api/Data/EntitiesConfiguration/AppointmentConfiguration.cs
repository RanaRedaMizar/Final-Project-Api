using Final_Project_Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Final_Project_Api.Data.EntitiesConfiguration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {

        public void Configure(EntityTypeBuilder<Appointment> builder)
        {


            builder
                .HasOne(appointment => appointment.Doctor)
                .WithMany(doctor => doctor.Appointments)
                .HasForeignKey(appointment => appointment.DoctorId);

         

            builder
                .HasMany(m => m.Medicines)
                .WithMany(p => p.Appointments)
                .UsingEntity<AppointmentMedicine>(
                a => a
                .HasOne(m => m.Medicine)
                .WithMany(am => am.AppointmentMedicines)
                .HasForeignKey(am => am.MedicineId),
                 a => a
                .HasOne(p => p.Appointment)
                .WithMany(am => am.AppointmentMedicines)
                .HasForeignKey(am => am.AppointmentId),
                 a =>
                 {
                  a.HasKey(m => new { m.AppointmentId, m.MedicineId });
                 });



            builder
                .HasMany(d => d.Diseases)
                .WithMany(p => p.Appointments)
                .UsingEntity<AppointmentDiagnose>(
                a => a
               .HasOne(m => m.Disease)
               .WithMany(am => am.AppointmentDiagnoses)
               .HasForeignKey(am => am.DiseaseId),
                a => a
               .HasOne(p => p.Appointment)
               .WithMany(d => d.AppointmentDiagnoses)
               .HasForeignKey(am => am.AppointmentId),  
                a =>
                {
                 a.HasKey(m => new { m.AppointmentId, m.DiseaseId });
                });


            builder.
                HasMany(d => d.AnalysisTypes)
               .WithMany(p => p.Appointments)
               .UsingEntity<AppointmentAnalysis>(
               a => a
               .HasOne(n => n.AnalysisType)
               .WithMany(am => am.AppointmentAnalysiss)
               .HasForeignKey(am => am.AnalysisTypeId),
                a => a
               .HasOne(p => p.Appointment)
               .WithMany(d => d.AppointmentAnalysiss)
               .HasForeignKey(am => am.AppointmentId),
                a =>
                 {
                 a.HasKey(m => new { m.AppointmentId, m.AnalysisTypeId });

                } );

        }
    }
}

