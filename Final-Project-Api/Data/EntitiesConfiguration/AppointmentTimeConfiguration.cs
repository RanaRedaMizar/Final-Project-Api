using Final_Project_Api.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Api.Data.EntitiesConfiguration
{
    public class AppointmentTimeConfiguration : IEntityTypeConfiguration<AppointmentTime>
    {
        public void Configure(EntityTypeBuilder<AppointmentTime> builder)
        {
            builder
                .HasOne(appointmentTime => appointmentTime.Appointment)
                .WithMany(appointment => appointment.AppointmentTimes)
                .HasForeignKey(appointmentTime => appointmentTime.AppointmentId);

        }
    }
}


