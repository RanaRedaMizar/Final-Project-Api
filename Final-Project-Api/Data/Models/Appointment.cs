using Final_Project_Api.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Final_Project_Api.Data.Models
{
    public class Appointment
    {
        [Key,Required]
        public int  AppointmentId { get; set; }
        public WeekDaysEnum Day { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public bool booked { get; set; } = false;
        public string DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
       



    }

}
