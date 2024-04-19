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

         

           

        }
    }
}

