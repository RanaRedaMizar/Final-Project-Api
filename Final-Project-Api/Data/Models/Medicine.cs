using System.ComponentModel.DataAnnotations;

namespace Final_Project_Api.Data.Models
{
    public partial class Medicine
    {
        [Key,Required]
        public int Id { get; set; }
        [Required]
        public string GenericName { get; set; } = null!;
        [Required]
        public string BrandName { get; set; } = null!;
        [Required]
        public string Type { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual List<AppointmentMedicine> AppointmentMedicines { get; set; }



    }

}
