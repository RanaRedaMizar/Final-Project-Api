using Final_Project_Api.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Api.Data.EntitiesConfiguration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(property => property.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder
                .HasOne(booking => booking.Patient)
                .WithMany(patient => patient.Bookings)
                .HasForeignKey(booking => booking.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
               .HasMany(m => m.Medicines)
               .WithMany(p => p.Bookings)
               .UsingEntity<AppointmentMedicine>(
               a => a
               .HasOne(m => m.Medicine)
               .WithMany(am => am.AppointmentMedicines)
               .HasForeignKey(am => am.MedicineId),
                a => a
               .HasOne(p => p.Booking)
               .WithMany(am => am.AppointmentMedicines)
               .HasForeignKey(am => am.BookingId),
                a =>
                {
                    a.HasKey(m => new { m.BookingId, m.MedicineId });
                });



            builder
                .HasMany(d => d.Diseases)
                .WithMany(p => p.Bookings)
                .UsingEntity<AppointmentDiagnose>(
                a => a
               .HasOne(m => m.Disease)
               .WithMany(am => am.AppointmentDiagnoses)
               .HasForeignKey(am => am.DiseaseId),
                a => a
               .HasOne(p => p.Booking)
               .WithMany(d => d.AppointmentDiagnoses)
               .HasForeignKey(am => am.BookingId),
                a =>
                {
                    a.HasKey(m => new { m.BookingId, m.DiseaseId });
                });


            builder.
                HasMany(d => d.AnalysisTypes)
               .WithMany(p => p.Bookings)
               .UsingEntity<AppointmentAnalysis>(
               a => a
               .HasOne(n => n.AnalysisType)
               .WithMany(am => am.AppointmentAnalysiss)
               .HasForeignKey(am => am.AnalysisTypeId),
                a => a
               .HasOne(p => p.Booking)
               .WithMany(d => d.AppointmentAnalysiss)
               .HasForeignKey(am => am.BookingId),
                a =>
                {
                    a.HasKey(m => new { m.BookingId, m.AnalysisTypeId });

                });
        }
    }
}
