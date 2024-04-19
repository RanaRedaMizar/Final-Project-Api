using System.ComponentModel.DataAnnotations;

namespace Final_Project_Api.Data.Models
{
    public partial class AppointmentMedicine
    {
        
        public string Description { get; set; } = null!;

        public int BookingId { get; set; }

        public int MedicineId { get; set; }

        public Booking Booking { get; set; }

        public Medicine Medicine { get; set; }


    }

}
