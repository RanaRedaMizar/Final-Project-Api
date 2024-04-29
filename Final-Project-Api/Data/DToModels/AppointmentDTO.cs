using Final_Project_Api.Data.Enums;
using Final_Project_Api.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Final_Project_Api.Data.DToModels
{
    public partial class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public WeekDaysEnum Day { get; set; }
        public string DoctorId { get; set; }
        [Required]
        public string Price { get; set; }
        public bool booked { get; set; } = false;
        public string Date { get; set; }
        
    }


}


