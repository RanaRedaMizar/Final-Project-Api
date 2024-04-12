using System.ComponentModel.DataAnnotations;

namespace Final_Project_Api.Data.Models
{
    public partial class AppointmentMedicine
    {
        
        public string Description { get; set; } = null!;

        public int AppointmentId { get; set; }

        public int MedicineId { get; set; }

        public Appointment Appointment { get; set; }

        public Medicine Medicine { get; set; }


    }

}
