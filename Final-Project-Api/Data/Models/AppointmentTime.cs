using System.ComponentModel.DataAnnotations;

namespace Final_Project_Api.Data.Models
{
    public class AppointmentTime
    {
        [Key,Required]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Appointment Appointment { get; set; }
        public int AppointmentId { get; set; }
       
    }
}

