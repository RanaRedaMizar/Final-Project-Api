using Final_Project_Api.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Final_Project_Api.Data.Models
{
    public class Booking
    {
        [Key,Required]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Price { get; set; }
        public int TotalBookings { get; set; }
        public BookingStatusEnum Status { get; set; } = BookingStatusEnum.Pending;
        public Appointment Appointment { get; set; }
        public int AppointmentId { get; set; }
        public Patient Patient { get; set; }
        public string PatientId { get; set; }
    }
}

